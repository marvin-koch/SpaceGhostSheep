using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys

public class MoveCelluloBehaviour : AgentBehaviour
{
    public int player;
    int input = -1;
    int colour = -1;

    public bool long_pressing;
    //public bool activeKey = true;
    private void Start()
    {

        long_pressing = false;
        this.gameObject.tag = "Player";
        getColor();

    }

    void Update()
    {
         getColor();       
    }

    private void getColor(){
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

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        input = (player == 2) ? PlayerSettings.input1 : PlayerSettings.input2;
        float horizontal = 0;
        float vertical = 0;
        if(!Timer.paused){

            if (input == 1)
            {
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
                steering.linear = new Vector3(horizontal, 0, vertical) * agent.maxAccel;
                steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.
                linear, agent.maxAccel));
            }
            else if(input == 0)
            {
                horizontal = Input.GetAxis("HorizontalWASD");
                vertical = Input.GetAxis("VerticalWASD");
                
                steering.linear = new Vector3(horizontal, 0, vertical) * agent.maxAccel;
                steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.
                linear, agent.maxAccel));
            } 
            else 
            {
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
            }

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


    public override void OnCelluloLongTouch(int key){
        long_pressing = true;
    }
}