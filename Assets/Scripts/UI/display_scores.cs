using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class display_scores : MonoBehaviour
{
    public GameObject[] players;
    private int score1;
    private TextMeshProUGUI text1;
    GameObject player1;

    private int score2;
    private TextMeshProUGUI text2;
    GameObject player2;

    private int score3;
    private TextMeshProUGUI text3;
    GameObject ia;

    // Start is called before the first frame update
    void Start()
    {
        //player1 = this.transform.parent.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        player1 = players[0];
        score1 = player1.GetComponent<public_variables>().score;
        text1 = this.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        text1.text = string.Format("Player 1\n{0}", score1);

        //player2 = this.transform.parent.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
        player2 = players[1];
        score2 = player2.GetComponent<public_variables>().score;
        text2 = this.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        text2.text = string.Format("Player 2\n{0}", score2);

        //ia = this.transform.parent.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject;
        ia = players[2];
        score3 = ia.GetComponent<public_variables>().score;
        text3 = this.transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        text3.text = string.Format("AI\n{0}", score3);
    }

    // Update is called once per frame
    void Update()
    {
        score1 = player1.GetComponent<public_variables>().score;
        text1.text = string.Format("Player 1\n{0}", score1);
        text1.color = PickTextColor(player1);

        score2 = player2.GetComponent<public_variables>().score;
        text2.text = string.Format("Player 2\n{0}", score2);
        text2.color = PickTextColor(player2);

        score3 = ia.GetComponent<public_variables>().score;
        text3.text = string.Format("AI\n{0}", score3);
        text3.color = PickTextColor(ia);

    }

    Color PickTextColor(GameObject player) {
        /*if (player.CompareTag("Monkey")) {
            return new Color(1f, 0.5f, 0f);
        }

        else if (player.CompareTag("Toucan")) {
            return Color.yellow;
        }

        else if (player.CompareTag("Sloth")) {
            return Color.black;
        }

        else return Color.white;
        */
        return player.GetComponent<CommonBehaviour>().FindCurrentColorOf();
    }
}
