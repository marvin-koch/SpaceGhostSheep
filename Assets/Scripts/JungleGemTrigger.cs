using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleGemTrigger : MonoBehaviour
{
    public AudioSource gemTaken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        gemTaken.Play();
        other.gameObject.GetComponent<public_variables>().score += 1;
        Destroy(this.gameObject);
    }
}
