using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JunglePlayerBehaviour : AgentBehaviour
{

    public bool long_pressing;
    float MONKEY_TOUCH_TIME = 3;
    float TOUCAN_TOUCH_TIME = 4;
    float SLOTH_TOUCH_TIME = 2;

    Color MONKEY_COLOR = new Color(1f, 0.5f, 0f); //brown
    Color TOUCAN_COLOR = Color.yellow;
    Color SLOTH_COLOR = Color.grey;
    float timer;

    public bool slothIsLazy = false;

    public float stamina = 0;

    public Slider slider;

    float timeOnTouch = 0;
    bool touchedPrey = false;
    public bool visualEffectSet = false;


    public int player;
    int input = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        //Set Color
        if(!Timer.paused && !visualEffectSet){
            this.GetComponent<CommonBehaviour>().SetColor(this.gameObject, false);
            visualEffectSet = true;
        }
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
            print("why are we here ?");
        }
        
        
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
                steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
            }

        }
        return steering;
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

