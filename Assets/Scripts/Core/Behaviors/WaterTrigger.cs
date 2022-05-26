using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaterTrigger : MonoBehaviour{

    void Start(){

    }

    void Update(){

    }

    void OnTriggerEnter(Collider other){
        GameObject player = other.transform.gameObject;
        if (player.CompareTag("Monkey")) {
            player.GetComponent<CelluloAgentRigidBody>().MoveOnMud();

        }else if(player.CompareTag("Toucan")){
            player.GetComponent<CelluloAgentRigidBody>().ClearHapticFeedback();
            player.GetComponent<CelluloAgentRigidBody>().SetCasualBackdriveAssistEnabled(true);

        }else if(player.CompareTag("Sloth")){
            player.GetComponent<CelluloAgentRigidBody>().MoveOnIce();
        }else{
            print("Mirco (this should not have been printed");
        }

    }

    void OnTriggerStay(Collider other){
        GameObject player = other.transform.gameObject;
        if (player.CompareTag("Monkey")) {
            player.GetComponent<CelluloAgentRigidBody>().MoveOnMud();

        }else if (player.CompareTag("Toucan")){
            if(player.GetComponent<JunglePlayerBehaviour>().stamina < 10){
                player.GetComponent<CelluloAgentRigidBody>().ClearHapticFeedback();
                player.GetComponent<CelluloAgentRigidBody>().SetCasualBackdriveAssistEnabled(true);
            }
            
        }else if(player.CompareTag("Sloth")){
            if(!player.GetComponent<JunglePlayerBehaviour>().slothIsLazy){
                player.GetComponent<CelluloAgentRigidBody>().MoveOnIce();
            }
        }else{
            print("Mirco (this should not have been printed");
        }
        
    }

    void OnTriggerExit(Collider other){
        GameObject player = other.transform.gameObject;
        if (player.CompareTag("Monkey")) {
            player.GetComponent<CelluloAgentRigidBody>().ClearHapticFeedback();
            player.GetComponent<CelluloAgentRigidBody>().SetCasualBackdriveAssistEnabled(true);
        }else if(player.CompareTag("Toucan")){
            player.GetComponent<CelluloAgentRigidBody>().ClearHapticFeedback();
            player.GetComponent<CelluloAgentRigidBody>().SetCasualBackdriveAssistEnabled(true);

        }else if(player.CompareTag("Sloth")){
            player.GetComponent<CelluloAgentRigidBody>().MoveOnMud();
        }else{
            print("Mirco (this should not have been printed");
        }

    }

}