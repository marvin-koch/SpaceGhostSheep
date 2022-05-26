using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidAnimalBehaviour : AgentBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<CommonBehaviour>().SetColor(this.gameObject, false);
    }
    
    public override Steering GetSteering()
    {
        Steering steering = new Steering();

        GameObject me = this.gameObject;
        Vector3 directionOfMovement = Vector3.zero;

        if (Distance(this.GetComponent<CommonBehaviour>().FindCurrentEnemy()) < 6.0)
        {
            directionOfMovement += me.transform.position - this.GetComponent<CommonBehaviour>().FindCurrentEnemy().transform.position;
        }
        else
        {
            directionOfMovement += this.GetComponent<CommonBehaviour>().FindCurrentPrey().transform.position - me.transform.position;
        }

        steering.linear = directionOfMovement * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        return steering;
    }

    public float Distance(GameObject o2)
    {
        return Vector3.Distance(this.gameObject.transform.position, o2.transform.position);
    }

   //Not used
    public GameObject Closest(GameObject o1, GameObject o2)
    {
        float o1d = Vector3.Distance(this.gameObject.transform.position, o1.transform.position);
        float o2d = Vector3.Distance(this.gameObject.transform.position, o2.transform.position);
        return o1d > o2d ? o2 : o1; 
    }
}
