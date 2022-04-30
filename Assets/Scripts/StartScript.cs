using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0;
        Timer.paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        //Time.timeScale = 1;
        Timer.paused = false;
    }
}
