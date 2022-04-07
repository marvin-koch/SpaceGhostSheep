using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
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
            --other.gameObject.GetComponent<public_variables>().score;
        }
    }
}
