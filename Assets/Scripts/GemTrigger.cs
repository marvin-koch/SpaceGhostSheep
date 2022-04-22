using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemTrigger : MonoBehaviour
{
    public AudioSource gemTaken;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.tag = "Gem";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gemTaken.Play();
            other.gameObject.GetComponent<public_variables>().stealer = true;
            print("Something touched the gem (me)");
            Destroy(this.gameObject);
            print("Should be destroyed");
        }
    }
}
