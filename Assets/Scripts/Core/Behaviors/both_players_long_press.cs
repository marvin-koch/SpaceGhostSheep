using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class both_players_long_press : MonoBehaviour
{
    public Button startButton;
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (players[0].GetComponent<real_cellulo_start>().long_pressing && players[1].GetComponent<real_cellulo_start>().long_pressing && startButton.gameObject.activeSelf) {
            startButton.onClick.Invoke();
            foreach (GameObject player in players) {
                player.GetComponent<real_cellulo_start>().long_pressing = false;
            }
        }
    }
}
