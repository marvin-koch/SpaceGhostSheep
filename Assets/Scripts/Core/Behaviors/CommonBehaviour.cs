using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBehaviour : AgentBehaviour
{
    Color RING_COLOR = Color.green;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    */

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

    public Color FindCurrentColorOf() {
        Color color = Color.white;
        switch (this.gameObject.tag)
        {
            case "Monkey": color = /** new Color(1f, 0.5f, 0f); */ Color.red;
                break;
            case "Sloth": color = Color.blue;
                break;
            case "Toucan": color = Color.yellow;
                break;
            default: print("Error : should not be in this case."); 
                break;
        }
        return color;
    }

    public void SetColor(GameObject gameObject, bool blinking){
        
        Color self = this.GetComponent<CommonBehaviour>().FindCurrentColorOf();
        GameObject prey_object = this.GetComponent<CommonBehaviour>().FindCurrentPrey();
        Color prey = prey_object.GetComponent<CommonBehaviour>().FindCurrentColorOf();
    
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, self, 0);
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, self, 1);
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, self, 2);
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, prey, 4);

        
        //VisualEffect effect = (JungleGameManager.gems > 0) ? VisualEffect.VisualEffectAlertSingle : VisualEffect.VisualEffectConstSingle;
        Color gemColor = (JungleGameManager.gems > 0) ? Color.white : Color.clear;
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, gemColor, 3);
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, gemColor, 5);

        

        //this.agent.SetVisualEffect(VisualEffect.VisualEffectConstSingle, prey, 5);
    }

    public void SetEndGameColor(bool winner) {
        Color color = (winner) ? Color.green : Color.red;
        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, color, 0);
    }
}
