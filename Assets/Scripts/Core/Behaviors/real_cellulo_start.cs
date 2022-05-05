using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class real_cellulo_start : AgentBehaviour
{
    public bool long_pressing;
    // Start is called before the first frame update
    void Start()
    {
        long_pressing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCelluloLongTouch(int key){
        long_pressing = true;
    }

}
