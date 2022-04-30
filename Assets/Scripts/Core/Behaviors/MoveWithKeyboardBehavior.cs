using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys

public class MoveWithKeyboardBehavior : AgentBehaviour
{
    public int player = 0;
    int input = 0;
    int colour = 0;
    private void Start()
    {

        this.gameObject.tag = "Player";

        colour = player == 2 ? PlayerSettings.colour1 : PlayerSettings.colour2;
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

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        if (!Timer.paused)
        {
            input = (player == 1) ? PlayerSettings.input1 : PlayerSettings.input2;
            float horizontal = 0;
            float vertical = 0;
            if(input == 0)
            {
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
            }
            else
            {
                horizontal = Input.GetAxis("HorizontalWASD");
                vertical = Input.GetAxis("VerticalWASD");
            }
            steering.linear = new Vector3(horizontal, 0,  vertical) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.
            linear, agent.maxAccel));
        }
        
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
