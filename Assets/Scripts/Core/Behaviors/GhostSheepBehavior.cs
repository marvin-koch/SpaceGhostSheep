using System.Linq;
using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{
    public GameObject[] players;
    public void Start(){
    }
    public override Steering GetSteering()
    {
        Vector3 directionOfMovement = Vector3.zero;
        Vector3 posOfThis = this.gameObject.transform.position;
        Vector3 posOfPlayer;
        Vector3 relativeDirection;

        foreach (GameObject player in players) {
            posOfPlayer = player.transform.position;
            
            if (Vector3.Distance(posOfPlayer, posOfThis) < 6.0)
            {
                relativeDirection = posOfThis - posOfPlayer;
                directionOfMovement += new Vector3(2 / relativeDirection.x, 0, 2 / relativeDirection.z);

            }
        }
        
        Steering steering = new Steering();
        steering.linear = directionOfMovement * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        return steering;
    }



}
