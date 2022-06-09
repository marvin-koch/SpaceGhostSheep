using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StupidAnimalBehaviour : AgentBehaviour
{
    public bool long_pressing;
    float MONKEY_TOUCH_TIME = 2;
    float TOUCAN_TOUCH_TIME = 2;
    float SLOTH_TOUCH_TIME = 2;

    Color MONKEY_COLOR = new Color(1f, 0.5f, 0f); //brown
    Color TOUCAN_COLOR = Color.yellow;
    Color SLOTH_COLOR = Color.black;
    float timer;

    public bool slothIsLazy = false;
    public Slider slider;

    public float stamina = 0;
    public bool visualEffectSet = false;


    float timeOnTouch = 0;
    bool touchedPrey = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<CommonBehaviour>().SetColor(this.gameObject, false);
          //Set Color
        if(!Timer.paused && !visualEffectSet){
            this.GetComponent<CommonBehaviour>().SetColor(this.gameObject, false);
            visualEffectSet = true;
        }
        /**
        if (this.gameObject.CompareTag("Monkey")){
            stamina = 0;
            slider.value = 15 -stamina;

        } else if (this.gameObject.CompareTag("Toucan")){
            if(!Timer.paused){
                stamina += Time.deltaTime;
                slider.value = 15 -stamina;
            }

            if(stamina >= 10){
                this.agent.MoveOnMud();
                
            }
            
        } else if (this.gameObject.CompareTag("Sloth")){
            if(!Timer.paused){
                stamina += Time.deltaTime;
                slider.value = 15 -stamina;
            }

            //Comment faire qu'on applle Random qu'une seule fois?

            if(stamina >= 15 && !(stamina >= 20)){
                if(!slothIsLazy){
                    var rng = new System.Random();
                    int mode = rng.Next(0,2);
                    switch(mode){
                        case 0:
                            this.agent.MoveOnStone();
                            break;
                        case 1:
                            this.agent.MoveOnMud();
                            break;
                        case 2:
                            this.agent.MoveOnSandpaper();
                            break;
                        default:
                            break;
                    }
                    slothIsLazy = true;
                }
            }
            
            if(stamina >= 20 && slothIsLazy){
                this.agent.MoveOnMud();
                stamina = 0;
                slothIsLazy = false;
            }
        } else {
            print("Wtf why are we here ?");
        }
        */
    }
    
    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        Vector3 directionOfMovement = Vector3.zero;

        if(!Timer.paused) {

            GameObject me = this.gameObject;

            if (Distance(this.GetComponent<CommonBehaviour>().FindCurrentEnemy()) < 6.0)
            {
                directionOfMovement += me.transform.position - this.GetComponent<CommonBehaviour>().FindCurrentEnemy().transform.position;
            }
            else
            {
                directionOfMovement += this.GetComponent<CommonBehaviour>().FindCurrentPrey().transform.position - me.transform.position;
            }

            steering.linear = directionOfMovement * (agent.maxAccel - 2);
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        }
        return steering;
    }

    public float Distance(GameObject o2)
    {
        return Vector3.Distance(this.gameObject.transform.position, o2.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("Monkey")) {
            touchedPrey = collision.gameObject.CompareTag("Toucan");
            timer = MONKEY_TOUCH_TIME;

        } else if (this.gameObject.CompareTag("Toucan")) {
            touchedPrey = collision.gameObject.CompareTag("Sloth");
            timer = TOUCAN_TOUCH_TIME;

        } else if (this.gameObject.CompareTag("Sloth")) {
            touchedPrey = collision.gameObject.CompareTag("Monkey");
            timer = SLOTH_TOUCH_TIME;
        }

        timeOnTouch = Timer.timeRemaining;
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (touchedPrey && !Timer.paused) {
            if (this.gameObject.CompareTag("Monkey")) {
                if (timer <= 0) {
                    this.GetComponent<public_variables>().score += 1;
                    timer = MONKEY_TOUCH_TIME;
                    this.transform.parent.gameObject.GetComponent<JungleGameManager>().assignRoles();
                } else {
                     timer -= Time.deltaTime;
                 }
            } else if (this.gameObject.CompareTag("Toucan")) {
                if (timer <= 0) {
                    this.GetComponent<public_variables>().score += 1;
                    timer = TOUCAN_TOUCH_TIME;
                    this.transform.parent.gameObject.GetComponent<JungleGameManager>().assignRoles();
                 } else {
                    timer -= Time.deltaTime;
                 }
            } else if (this.gameObject.CompareTag("Sloth")) {
                if (timer <= 0) {
                    this.GetComponent<public_variables>().score += 1;
                    timer = SLOTH_TOUCH_TIME;
                    this.transform.parent.gameObject.GetComponent<JungleGameManager>().assignRoles();
                } else {
                    timer -= Time.deltaTime;
                }
            }
        }
    }

    public override void OnCelluloLongTouch(int key){
        long_pressing = true;
    }
}
