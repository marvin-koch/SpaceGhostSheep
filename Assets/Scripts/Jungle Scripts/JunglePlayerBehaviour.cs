using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunglePlayerBehaviour : AgentBehaviour
{

    

    public bool long_pressing;
    int MONKEY_TOUCH_TIME = 2;
    int TOUCAN_TOUCH_TIME = 2;
    int SLOTH_TOUCH_TIME = 2;

    public int player;
    int input = 0;

    Color MONKEY_COLOR = new Color(1f, 0.5f, 0f); //brown
    Color TOUCAN_COLOR = Color.yellow;
    Color SLOTH_COLOR = Color.grey;
    Color RING_COLOR = Color.green;
    float timer;

    public bool slothIsLazy = false;

    public float stamina = 0;



    float timeOnTouch = 0;
    bool touchedPrey = false;
    // Start is called before the first frame update

    /*
    void SetColor(Color playerColor, Color targetColor, Color ringColor){
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, targetColor, 0);
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, targetColor, 1);
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, targetColor, 2);
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, playerColor, 3);
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, ringColor, 4);
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, playerColor, 5);
    }
    */

    void SetColor(GameObject gameObject, bool blinking){
        
        Color self = SAB.FindCurrentColorOf(this.gameObject);
        Color prey = SAB.FindCurrentColorOf(SAB.FindCurrentPrey());

        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, prey, 0);
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, prey, 1);
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, prey, 2);
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, self, 3);
    
        VisualEffect effect = blinking ? VisualEffect.VisualEffectAlertSingle : VisualEffect.VisualEffectConstSingle;
        this.agent.setVisualEffect(effect, RING_COLOR, 4);
    
        this.agent.setVisualEffect(VisualEffect.VisualEffectConstSingle, self, 5);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Set Color
        SetColor(SAB.FindCurrentColorOf(this.gameObject), SAB.FindCurrentColorOf(SAB.FindCurrentPrey()), RING_COLOR);
        if (this.gameObject.CompareTag("Monkey")){

            stamina = 0;

        } else if (this.gameObject.CompareTag("Toucan")){
            if(!Timer.paused){
                stamina += Time.deltaTime;
            }

            if(stamina >= 10){
                this.agent.MoveOnMud();
                
            }
            
        } else if (this.gameObject.CompareTag("Sloth")){
            if(!Timer.paused){
                stamina += Time.deltaTime;
            }

            //Comment faire qu'on applle Random qu'une seule fois?

            if(stamina >= 10 && !(stamina >= 15)){
                if(!slothIsLazy){
                    var rng = new System.Random();
                    int mode = rng.Next(0,3);
                    switch(mode){
                        case 0:
                            this.agent.MoveOnStone();
                            break;
                        case 1:
                            this.agent.MoveOnMud();
                            break;
                        case 2:
                            this.agent.MoveOnIce();
                            break;
                        case 3:
                            this.agent.MoveOnSandpaper();
                            break;
                        default:
                            break;
                    }
                    slothIsLazy = true;
                }
            }
            
            if(stamina >= 15){
                if(slothIsLazy){
                    this.agent.MoveOnMud();
                    stamina = 0;
                    slothIsLazy = false;

                }
            }

        } else {
            print("Wtf why are we here ?");
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
                    //Impelement change of roles
                    JungleGameManager.assignRoles();
                }else{
                    if(!Timer.paused){
                        timer -= Time.deltaTime;
                    }
                }
            }else if(this.gameObject.CompareTag("Toucan")){
                if(timer <= 0){
                    this.GetComponent<public_variables>().score += 1;
                    JungleGameManager.assignRoles();
                }else{
                    if(!Timer.paused){
                        timer -= Time.deltaTime;
                    }
                }
            }else if(this.gameObject.CompareTag("Sloth")){
                if(timer <= 0){
                    this.GetComponent<public_variables>().score += 1;
                    JungleGameManager.assignRoles();
                }else{
                    if(!Timer.paused){
                        timer -= Time.deltaTime;
                    }
                }
            }
        }
    }




    public override void OnCelluloLongTouch(int key){
        long_pressing = true;
    }
}
