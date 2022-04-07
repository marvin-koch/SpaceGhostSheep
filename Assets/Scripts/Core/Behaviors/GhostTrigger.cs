using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    public AudioSource lostPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        
        if (this.gameObject.CompareTag("Ghost") && other.gameObject.CompareTag("Player")) {
            Debug.Log(other.transform.parent.gameObject.name + " collides.");
            --other.gameObject.GetComponent<public_variables>().score;
            lostPoint.Play();
        }
    }
}
