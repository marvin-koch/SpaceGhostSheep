using System.Linq;
using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{
    public GameObject[] players;
    public bool isGhost;

    public AudioSource sheep;
    public AudioSource ghost;
    private bool hastStarted = true;
    private bool alreadyConnected = false;
    public void Start()
    {
        float startTime = PlayerSettings.time;
        hastStarted = true;
        becomesSheep();
        hastStarted = false;

        float minute = 60.0f;
        //for (int i = 0; i < (int) startTime/5; ++i)
        //{
        //Invoke("becomesGhost", Random.Range(35.0f + i * minute, 45.0f + i * minute));
        //Invoke("becomesSheep", Random.Range(55.0f + i * minute, 65.0f + i * minute));

        //}
        InvokeRepeating("becomesGhost", Random.Range(35.0f , 45.0f), minute);
        InvokeRepeating("becomesSheep", Random.Range(55.0f, 65.0f), minute);
    }

    public void Update()
    {   
        if (this.agent.isConnected && !alreadyConnected)
        {
            Start();
            alreadyConnected = true;
        }
        
        
        /*
        if (isGhost)
        {
            this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.yellow, 128);
        } 
        else
        {
            this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 128);
        }
        */
    }

    public override Steering GetSteering()
    {
        Vector3 directionOfMovement = Vector3.zero;
        Steering steering = new Steering();

        if (!Timer.paused)
        {
            if (isGhost)
            {
                GameObject target = FindClosestEnemy();
                directionOfMovement = target.gameObject.transform.position - this.gameObject.transform.position;
                directionOfMovement = directionOfMovement / 2;
                //directionOfMovement = directionOfMovement.normalized;

            }
            else
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
        }
        print("Ciao je suis executé");
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
        if (!Timer.paused || hastStarted)
        {
            isGhost = true;
            this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.yellow, 128);
            this.tag = ("Ghost");
            ghost.Play();
        }

        //real cellulo are hard to move
        foreach (GameObject player in players) {
            player.GetComponent<CelluloAgentRigidBody>().SetCasualBackdriveAssistEnabled(false);
            player.GetComponent<CelluloAgentRigidBody>().MoveOnStone();

        }
        
    }

    void becomesSheep()
    {
        if (!Timer.paused|| hastStarted)
        {
            isGhost = false;
            this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 128);
            this.tag = ("Sheep");
            sheep.Play();
        }

        //real cellulo are easy to move
        foreach (GameObject player in players) {
            player.GetComponent<CelluloAgentRigidBody>().SetCasualBackdriveAssistEnabled(true);
        }
        
    }

    
}