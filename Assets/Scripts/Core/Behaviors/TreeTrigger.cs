using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TreeTrigger : MonoBehaviour{

    void Start(){

    }

    void Update(){

    }

    void OnTriggerEnter(Collider other){
        GameObject player = other.transform.gameObject;
        if(player.CompareTag("Toucan")){
            player.GetComponent<JunglePlayerBehaviour>().stamina = 0;
        }
    }

    void OnTriggerStay(Collider other){
        GameObject player = other.transform.gameObject;
        if(player.CompareTag("Toucan")){
            player.GetComponent<JunglePlayerBehaviour>().stamina = 0;
        }
    }


    void OnTriggerExit(Collider other){
        GameObject player = other.transform.gameObject;
        if(player.CompareTag("Toucan")){
            player.GetComponent<JunglePlayerBehaviour>().stamina = 0;
        }

    }

}