using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    public AudioSource wonPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other){
         
        if (other.transform.parent.gameObject.CompareTag("Sheep")) {
            GameObject[] players = other.GetComponentInParent<GhostSheepBehavior>().players;
            Vector3 sheepPosition = this.gameObject.transform.position;
            if (Vector3.Distance(players[0].transform.position, sheepPosition) < Vector3.Distance(players[1].transform.position, sheepPosition)) {
                ++players[0].GetComponent<public_variables>().score;
                wonPoint.Play();
            }
            else {
                ++players[1].GetComponent<public_variables>().score;
                wonPoint.Play();

            }
        }    
        
    }
}
