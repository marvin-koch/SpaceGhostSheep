using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : AgentBehaviour
{
    // Start is called before the first frame update
    public int player = 0;
    int colour = 0;
    void Start()
    {
        colour = player == 1 ? PlayerSettings.colour1 : PlayerSettings.colour2;
        Color leds = Color.white;
        if(colour == 0)
        {
            leds = Color.blue;
        }else if(colour == 1)
        {
            leds = Color.red;
        }
        else
        {
            leds = Color.black;
        }

        this.agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, leds, 128);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
