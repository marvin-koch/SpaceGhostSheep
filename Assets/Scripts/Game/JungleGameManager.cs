using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleGameManager : MonoBehaviour
{
    public GameObject jungleGem;
    public GameObject[] players;
    public float gemTime = 45f;
    public static int gems = 0;
    public string[] tagsTable = {"Monkey", "Toucan", "Sloth"};

    void Start()
    {
        assignRoles();
        InvokeRepeating("instantiateGem", 30f, gemTime);
    }

    static void shuffle(string[] array)
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
        //return array;

        /**
        var t0 = array[0];
        var t1 = array[1];
        var t2 = array[2];

        array[0] = t2;
        array[1] = t0;
        array[2] = t1;
        */
    }

  
    public void Shuffle(string[] array) {
        for (int i = 0; i < array.Length; i++) {
            int rnd = Random.Range(0, array.Length);
            string tempGO = array[rnd];
            array[rnd] = array[i];
            array[i] = tempGO;
        }
    }
    public void assignRoles()
    {
        //shuffle(tagsTable);
        Shuffle(tagsTable);
        //var rng = new System.Random(); //burkina faso
        //var shuffledTags = tagsTable.OrderBy(a => rng.Next()).ToList();
        for(int i = 0; i < 3; ++i){
            players[i].tag = tagsTable[i];
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
            gems += 1;
            for(int i = 0; i < 3; ++i){
                players[i].tag = tagsTable[i];
                if(players[i].GetComponent<JunglePlayerBehaviour>() == null){
                    players[i].GetComponent<StupidAnimalBehaviour>().visualEffectSet = false;
                }else{
                    players[i].GetComponent<JunglePlayerBehaviour>().visualEffectSet = false;
                }
            }
            float x = 14.49f;
            float z = -10.23f;
            clone.transform.SetPositionAndRotation(new Vector3(x, 0, z), Quaternion.identity);
        }
    }

    public static void endOfGame() {
        
    }
  
}