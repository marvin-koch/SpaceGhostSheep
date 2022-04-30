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
        // input = 
        // 0 -> WASD
        // 1 -> ARROWS
        // 2 -> MOUSE

        /**
        bool player1isMouse = PlayerSettings.input1 == 2;
        bool player2isMouse = PlayerSettings.input2 == 2;
        print("Joueur 1 a l'input : " + PlayerSettings.input1);
        print("Joueur 2 a l'input : " + PlayerSettings.input2);

        if (!player1isMouse)
        {
            //player1.AddComponent<MoveWithKeyboardBehavior>();
            player1.GetComponent<MoveWithKeyboardBehavior>().activeKey = true;
            player1.GetComponent<MoveWithMouseBehavior>().activeMouse = false;
            print("player1 IS NOT MOUSE");
            player1.GetComponent<MoveWithKeyboardBehavior>().player = 1;
        }
        else
        {
            //player1.AddComponent<MoveWithMouseBehavior>();
            player1.GetComponent<MoveWithKeyboardBehavior>().activeKey = false;
            player1.GetComponent<MoveWithMouseBehavior>().activeMouse = true;
            player1.GetComponent<MoveWithMouseBehavior>().player = 1;
            print("player1 IS MOUSE");
        }

        if (!player2isMouse)
        {
            player2.GetComponent<MoveWithKeyboardBehavior>().activeKey = true;
            player2.GetComponent<MoveWithMouseBehavior>().activeMouse = false;
            player2.GetComponent<MoveWithKeyboardBehavior>().player = 2;
            print("player2 IS NOT MOUSE");
        }
        else
        {
            player2.GetComponent<MoveWithMouseBehavior>().activeMouse = true;
            player2.GetComponent<MoveWithKeyboardBehavior>().activeKey = false;
            player2.GetComponent<MoveWithMouseBehavior>().player = 2;
            print("player2 IS MOUSE");

        }
        */

        bool player1isMouse = PlayerSettings.input1 == 2;
        bool player2isMouse = PlayerSettings.input2 == 2;

        if(player1isMouse){
            player1.GetComponent<MoveWithMouseBehavior>().enabled = true;
        }else{

            player1.GetComponent<MoveWithKeyboardBehavior>().enabled = true;
        }

        if(player2isMouse){
            player2.GetComponent<MoveWithMouseBehavior>().enabled = true;
        }else{

            player2.GetComponent<MoveWithKeyboardBehavior>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
