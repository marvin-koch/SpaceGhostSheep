using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExemple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
        Debug.Log("there are " + collisionInfo.contacts.Length + " point(s) of contacts");
        Debug.Log("Their relative velocity is " + collisionInfo.relativeVelocity);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        Debug.Log(gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
