using System.Linq;
using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{
    public GameObject[] players;
    public bool isGhost;
    public void Start(){
        becomesSheep();
        float shift = 30.0f;
        for (int i = 0; i < 5; ++i)
        {
            Invoke("becomesGhost", Random.Range(15.0f + i * shift, 25.0f + i * shift));
            Invoke("becomesSheep", Random.Range(25.0f + i * shift, 35.0f + i * shift));
        }
    }
    public override Steering GetSteering()
    {
        Vector3 directionOfMovement = Vector3.zero;
        Steering steering = new Steering();

        if (isGhost)
        {
            GameObject target = FindClosestEnemy();
            directionOfMovement = target.gameObject.transform.position - this.gameObject.transform.position;
            //directionOfMovement = directionOfMovement.normalized;

        } else
        {
            
            Vector3 posOfThis = this.gameObject.transform.position;
            Vector3 posOfPlayer;
            Vector3 relativeDirection;

            foreach (GameObject player in players)
            {
                posOfPlayer = player.transform.position;

                if (Vector3.Distance(posOfPlayer, posOfThis) < 6.0)
                {
                    relativeDirection = posOfThis - posOfPlayer;
                    directionOfMovement += new Vector3(2 / relativeDirection.x, 0, 2 / relativeDirection.z);

                }
            }
        }

        steering.linear = directionOfMovement * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));

        return steering;
    }

    public GameObject FindClosestEnemy()
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = this.gameObject.transform.position;
        foreach (GameObject player in players)
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }
        return closest;
    }

        void becomesGhost()
    {
        isGhost = true;
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.yellow, 128);
        this.tag = ("Ghost");
    }

        void becomesSheep()
    {
        isGhost = false;
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 128);
        this.tag = ("Sheep");

    }
}
