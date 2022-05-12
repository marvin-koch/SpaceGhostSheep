using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleGameManager : MonoBehaviour
{
    public GameObject[] players;
    public string[] tagsTable = {"Monkey", "Toucan", "Sloth"};

    public List<string> tags = new List<string>(tagsTable);

    
    void assignRoles()
    {

        Random rng = new Random();
        var shuffledcards = tags.OrderBy(a => rng.Next()).ToList();
        //


    }
 


}