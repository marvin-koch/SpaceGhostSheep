using UnityEngine;
using System.Collections;

public class MoveWithMouseBehavior : AgentBehaviour
{
    Vector3 position;
    Vector3 direction;
    //public bool activeMouse = true;
    int colour;

    int player = 0;

   private void Start()
    {

        this.gameObject.tag = "Player";

        colour = (player == 2) ? PlayerSettings.colour1 : PlayerSettings.colour2;
        Color leds = Color.white;
        if (colour == 0)
        {
            leds = Color.blue;
        }
        else if (colour == 1)
        {
            leds = Color.red;
        }
        else
        {
            leds = Color.black;
        }

        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, leds, 128);
    }
    void Update()
    {
       
    }

    /**
    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        input = (player == 1) ? PlayerSettings.input1 : PlayerSettings.input2;
        //print(string.Format("Mouse Player {0} is active : {1}", player, activeMouse));
        if (input == 2)
        {
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
        }
       
        return steering;
    }
    */
    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        Vector3 position;
        Vector3 direction;
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

        //}
       
        return steering;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.GetComponent<public_variables>().stealer)
        {
            this.GetComponent<public_variables>().score = this.GetComponent<public_variables>().score + 2;
            collision.gameObject.GetComponent<public_variables>().score = collision.gameObject.GetComponent<public_variables>().score - 2;
            this.GetComponent<public_variables>().stealer = false;
            
        }
    }
}