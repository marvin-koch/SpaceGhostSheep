using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunglePlayerBehaviour : AgentBehaviour
{
    int MONKEY_TOUCH_TIME = 2;
    int TOUCAN_TOUCH_TIME = 2;
    int SLOTH_TOUCH_TIME = 2;

    int timer;


    int timeOnTouch = 0;
    bool touchedPrey = false;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        input = (player == 2) ? PlayerSettings.input1 : PlayerSettings.input2;
        float horizontal = 0;
        float vertical = 0;
        //print(string.Format("Keyboard Player {0} is active : {1}", player, activeKey));
        //if (input == 0 || input == 1)
        //{
            //print(string.Format("Keyboard Player {0} input is  : {1}", player, input));
        if(!Timer.paused){

            if (input == 1)
            {

                //print("Getting Arrows");
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
                steering.linear = new Vector3(horizontal, 0, vertical) * agent.maxAccel;
                steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.
                linear, agent.maxAccel));
            }
            else if(input == 0)
            {
                //print("Getting WASD");
                horizontal = Input.GetAxis("HorizontalWASD");
                vertical = Input.GetAxis("VerticalWASD");
                //print("Finished WASD");
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
        /**
        if (collision.gameObject.CompareTag("Player") && this.GetComponent<public_variables>().stealer)
        {
            this.GetComponent<public_variables>().score = this.GetComponent<public_variables>().score + 2;
            collision.gameObject.GetComponent<public_variables>().score = collision.gameObject.GetComponent<public_variables>().score - 2;
            this.GetComponent<public_variables>().stealer = false;
            
        }
        */

        if(this.gameObject.CompareTag("Monkey")){
            touchedPrey = collision.gameObject.CompareTag("Toucan");
            timer = MONKEY_TOUCH_TIME;

        }else if(this.gameObject.CompareTag("Toucan")){
            touchedPrey = collision.gameObject.CompareTag("Sloth");
            timer = TOUCAN_TOUCH_TIME;
        }else if(this.gameObject.CompareTag("Sloth")){
            touchedPrey = collision.gameObject.CompareTag("Monkey");
            timer = SLOTH_TOUCH_TIME;
        }

        timeOnTouch = Timer.timeRemaining;

    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if(touchedPrey){
            if(this.gameObject.CompareTag("Monkey")){
                if(timer <= 0){
                    this.GetComponent<public_variables>().score += 1;
                }else{
                    timer - Time.deltaTime;
                }
                
            }else if(this.gameObject.CompareTag("Toucan")){
                if(timer <= 0){
                    this.GetComponent<public_variables>().score += 1;
                }else{
                    timer - Time.deltaTime;
                }
            }else if(this.gameObject.CompareTag("Sloth")){
                if(timer <= 0){
                    this.GetComponent<public_variables>().score += 1;
                }else{
                    timer - Time.deltaTime;
                }
            }
        }
    }

    private void OnCollisionExit(CollectionExtensions collision){

        // Compare le temps à l'entrée et la sorte
        if(touchedPrey){
            if(this.gameObject.CompareTag("Monkey")){
                if((timeOnTouch - Timer.timeRemaining) == MONKEY_TOUCH_TIME){
                    this.GetComponent<public_variables>().score += 1;
                }
                
            }else if(this.gameObject.CompareTag("Toucan")){
                if((timeOnTouch - Timer.timeRemaining) == TOUCAN_TOUCH_TIME){
                    this.GetComponent<public_variables>().score += 1;
                }
            }else if(this.gameObject.CompareTag("Sloth")){
                if((timeOnTouch - Timer.timeRemaining) == SLOTH_TOUCH_TIME){
                    this.GetComponent<public_variables>().score += 1;
                }
            }
        }
        


    }



    public override void OnCelluloLongTouch(int key){
        long_pressing = true;
    }
}
