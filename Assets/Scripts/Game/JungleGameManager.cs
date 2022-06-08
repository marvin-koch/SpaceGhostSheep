using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleGameManager : MonoBehaviour
{
    public GameObject jungleGem;
    public GameObject[] players;
    public float gemTime = 45f;
    public string[] tagsTable = {"Monkey", "Toucan", "Sloth"};

    void Start()
    {
        assignRoles();
        InvokeRepeating("instantiateGem", 30f, gemTime);
    }

    static string[] shuffle(string[] array)
    {
        int p = array.Length;
        for (int n = p-1; n > 0 ; n--)
        {
            var rng = new System.Random();
            int r = rng.Next(1, n);
            string t = array[r];
            array[r] = array[n];
            array[n] = t;
        }
        return array;
    }

    public void assignRoles()
    {
        var array = shuffle(tagsTable);
        //var rng = new System.Random(); //burkina faso
        //var shuffledTags = tagsTable.OrderBy(a => rng.Next()).ToList();
        for(int i = 0; i < 3; ++i){
            players[i].tag = array[i];
            if(players[i].GetComponent<JunglePlayerBehaviour>() == null){
                players[i].GetComponent<StupidAnimalBehaviour>().visualEffectSet = false;
            }else{
                players[i].GetComponent<JunglePlayerBehaviour>().visualEffectSet = false;
            }
        }
    }

    public void instantiateGem() {
        if (!Timer.paused) {
            GameObject clone = Instantiate(jungleGem);
            float x = 14.49f;
            float z = -10.23f;
            clone.transform.SetPositionAndRotation(new Vector3(x, 0, z), Quaternion.identity);
        }
    }
}