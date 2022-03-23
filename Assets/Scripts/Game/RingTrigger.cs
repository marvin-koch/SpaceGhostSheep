using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other){
        Debug.Log(other.transform.parent.gameObject.name + " triggers.");

        other.GetComponent<Cellulo>().SetLEDResponseMode(12);
        other.GetComponent<Cellulo>().SetVisualEffect((long)12,(long) 255, (long)0, (long)0, (long)(12));
        
    }
}
