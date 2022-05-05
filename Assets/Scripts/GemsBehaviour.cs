using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsBehaviour : MonoBehaviour
{
    public GameObject spaceGem;
    public GameObject timeGem;
    public int maxMinutes = PlayerSettings.time;
    // Start is called before the first frame update
    void Start()
    {

        //for (int i = 0; i < maxMinutes; ++i)
        //{
        
        InvokeRepeating("instantiateSpaceGem", 30f,60f);
        InvokeRepeating("instantiateTimeGem", 60f , 60f);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void instantiateSpaceGem()
    {
        if (!Timer.paused)
        { 
            float x = Random.Range(1, 27);
            float z = Random.Range(-19, -1);
            GameObject clone = Instantiate(spaceGem);
            clone.transform.SetPositionAndRotation(new Vector3(x, 0, z), Quaternion.identity);
        }
    }

    void instantiateTimeGem()
    {
        if (!Timer.paused)
        {
            float x = Random.Range(1, 27);
            float z = Random.Range(-19, -1);
            GameObject clone = Instantiate(timeGem);
            clone.transform.SetPositionAndRotation(new Vector3(x, 0, z), Quaternion.identity);
        }    
    }



}
