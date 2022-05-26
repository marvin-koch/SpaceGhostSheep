using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleGameManager : MonoBehaviour
{
    public static GameObject[] players;
    public static string[] tagsTable = {"Monkey", "Toucan", "Sloth"};
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
    public static void assignRoles()
    {
        var array = shuffle(tagsTable);
        //var rng = new System.Random(); //burkina faso
        //var shuffledTags = tagsTable.OrderBy(a => rng.Next()).ToList();
        for(int i = 0; i < 3; ++i){
            players[i].tag = array[i];
        }
    }
}