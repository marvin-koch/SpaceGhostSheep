using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsBehaviour : MonoBehaviour
{
    public GameObject gem;
    public int maxMinutes = PlayerSettings.time;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < maxMinutes; ++i)
        {
            Invoke("instantiateGem", 60f * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void instantiateGem()
    {
        float x = Random.Range(1, 27);
        float z = Random.Range(-19, -1);
        GameObject clone = Instantiate(gem);
        clone.transform.SetPositionAndRotation(new Vector3(x, 0, z), Quaternion.identity);
    }
}
