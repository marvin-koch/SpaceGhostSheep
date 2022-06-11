using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSettings : MonoBehaviour
{
    public static int input1 = 0;
    public static int input2 = 1;
    public static int time = 5;
    public static int colour1 = 0;
    public static int colour2 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setInput1(int inputIndex)
    {
        input1 = inputIndex;
    }

    public void setInput2(int inputIndex)
    {
        input2 = inputIndex;
    }

    public void setTime(int t)
    {
        time = t + 1;
    }

    public void setColour1(int c)
    {
        colour1 = c;
    }

    public void setColour2(int c)
    {
        colour2 = c;
    }
}
