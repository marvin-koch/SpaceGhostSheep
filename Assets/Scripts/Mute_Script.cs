using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void muteToggle(bool muted)
    {
        AudioListener.volume = muted ? 0 : 1;
    }
}
