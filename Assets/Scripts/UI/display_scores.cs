using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class display_scores : MonoBehaviour
{
    private int score1;
    private TextMeshProUGUI text1;
    GameObject player1;

    private int score2;
    private TextMeshProUGUI text2;
    GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = this.transform.parent.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        score1 = player1.GetComponent<public_variables>().score;
        text1 = this.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        text1.text = string.Format("Player 1\n{0}", score1);

        player2 = this.transform.parent.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
        score2 = player2.GetComponent<public_variables>().score;
        text2 = this.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        text2.text = string.Format("Player 2\n{0}", score2);
    }

    // Update is called once per frame
    void Update()
    {
        score1 = player1.GetComponent<public_variables>().score;
        text1.text = string.Format("Player 1\n{0}", score1);

        score2 = player2.GetComponent<public_variables>().score;
        text2.text = string.Format("Player 2\n{0}", score2);
    }
}
