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
        Color color = FindCurrentColorOf(this.gameObject);
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, color, 128);
    }
    
    public override Steering GetSteering()
    {
        Steering steering = new Steering();

        GameObject me = this.gameObject;
        Vector3 directionOfMovement = Vector3.zero;

        if (Distance(me, FindCurrentEnemy()) < 6.0)
        {
            directionOfMovement += me.transform.position - FindCurrentEnemy().transform.position;
        }
        else
        {
            directionOfMovement += FindCurrentPrey().transform.position - me.transform.position;
        }

        steering.linear = directionOfMovement * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        return steering;
    }

    public Color FindCurrentColorOf(GameObject gameObject) {
        Color color = Color.white;
        switch (gameObject.tag)
        {
            case "Monkey": color = new Color(1f, 0.5f, 0f);
                break;
            case "Sloth": color = Color.black;
                break;
            case "Toucan": color = Color.yellow;
                break;
            default: print("Error : should not be in this case."); 
                break;
        }
        return color;
    }

    public GameObject FindCurrentEnemy()
    {
        GameObject enemy = null;
        switch (this.gameObject.tag)
        {
            case "Monkey" : enemy = GameObject.FindWithTag("Sloth"); 
                break;
            case "Sloth" : enemy = GameObject.FindWithTag("Toucan"); 
                break;
            case "Toucan": enemy = GameObject.FindWithTag("Monkey"); 
                break;
            default : print("Error : should not be in this case."); enemy = null; 
                break;
        }
        return enemy;
    }

    public GameObject FindCurrentPrey()
    {
        GameObject prey = null;
        switch (this.gameObject.tag)
        {
            case "Monkey": prey = GameObject.FindWithTag("Toucan"); 
                break;
            case "Sloth": prey = GameObject.FindWithTag("Monkey"); 
                break;
            case "Toucan": prey = GameObject.FindWithTag("Sloth"); 
                break;
            default: print("Error : should not be in this case."); prey = null; 
                break;
        }
        return prey;
    }

    public float Distance(GameObject o1, GameObject o2)
    {
        return Vector3.Distance(o1.transform.position, o2.transform.position);
    }

   //Not used
    public GameObject Closest(GameObject o1, GameObject o2)
    {
        float o1d = Vector3.Distance(this.gameObject.transform.position, o1.transform.position);
        float o2d = Vector3.Distance(this.gameObject.transform.position, o2.transform.position);
        return o1d > o2d ? o2 : o1; 
    }
    

}
