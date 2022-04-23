using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGemTrigger : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject col = collision.gameObject;

        if (col.CompareTag("Player"))
        {
            bool player1wins = player1.GetComponent<public_variables>().score > player2.GetComponent<public_variables>().score;

            if (player1.GetComponent<public_variables>().score == player2.GetComponent<public_variables>().score)
            {
                Timer.timeRemaining -= Timer.timeRemaining * 1 / 20;
            }
            else
            {
                if ((GameObject.ReferenceEquals(player1, col) && player1wins) || (GameObject.ReferenceEquals(player2, col) && !player1wins))
                {
                    Timer.timeRemaining -= Timer.timeRemaining * 1 / 20;
                }
                else
                {
                    Timer.timeRemaining += Timer.timeRemaining * 1 / 20;
                }
            }

            Destroy(this.gameObject);
        }
        
    }
}
