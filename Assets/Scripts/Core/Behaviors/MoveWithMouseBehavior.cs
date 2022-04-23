using UnityEngine;
using System.Collections;

public class MoveWithMouseBehavior : AgentBehaviour
{
    Vector3 position;
    Vector3 direction;

    void Start()
    {

    }

    void Update()
    {
       
    }

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        if (Input.GetMouseButton(0))
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (position - transform.position).normalized;
            
        }
        else
        {
            direction = Vector3.zero;
        }
        steering.linear = direction * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.
        linear, agent.maxAccel));
        return steering;
    }
}