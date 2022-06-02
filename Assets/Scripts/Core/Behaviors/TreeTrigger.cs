using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TreeTrigger : MonoBehaviour{

    void Start(){

    }

    void Update(){

    }

    void OnTriggerEnter(Collider other){
        GameObject player = other.transform.parent.gameObject;
        var component = player.GetComponent<JunglePlayerBehaviour>() == null ? player.GetComponent<StupidAnimalBehaviour>() : player.GetComponent<JunglePlayerBehaviour>();
        if(player.CompareTag("Toucan")){
            component.stamina = 0;
        }
    }

    void OnTriggerStay(Collider other){
        GameObject player = other.transform.parent.gameObject;
        var component = player.GetComponent<JunglePlayerBehaviour>() == null ? player.GetComponent<StupidAnimalBehaviour>() : player.GetComponent<JunglePlayerBehaviour>();

        if(player.CompareTag("Toucan")){
            component.stamina = 0;
        }
    }

    void OnTriggerExit(Collider other){
        GameObject player = other.transform.parent.gameObject;
        var component = player.GetComponent<JunglePlayerBehaviour>() == null ? player.GetComponent<StupidAnimalBehaviour>() : player.GetComponent<JunglePlayerBehaviour>();

        if(player.CompareTag("Toucan")){
            component.stamina = 0;
        }

    }

}