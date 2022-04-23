using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChoosePlayerBehaviour : AgentBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    void Start()
    {
        bool player1isMouse = !(PlayerSettings.input1 == 0 || PlayerSettings.input1 == 1);
        bool player2isMouse = !(PlayerSettings.input2 == 0 || PlayerSettings.input2 == 1);

        print(player1isMouse);
        if (!player1isMouse)
        {
            player1.AddComponent<MoveWithKeyboardBehavior>();
            player1.GetComponent<MoveWithKeyboardBehavior>().enabled = true;

            player1.GetComponent<MoveWithKeyboardBehavior>().player = 1;


        }
        else
        {
            player1.AddComponent<MoveWithMouseBehavior>();
            player1.GetComponent<MoveWithMouseBehavior>().enabled = true;

        }

        if (!player2isMouse)
        {
            player2.AddComponent<MoveWithKeyboardBehavior>();
            player2.GetComponent<MoveWithKeyboardBehavior>().enabled = true;

            player2.GetComponent<MoveWithKeyboardBehavior>().player = 2;

        }
        else
        {
            player2.AddComponent<MoveWithMouseBehavior>();
            player2.GetComponent<MoveWithMouseBehavior>().enabled = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
