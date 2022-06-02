using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scores : MonoBehaviour
{

    private int score1;
    private TextMeshProUGUI text1;

    private int score2;
    private TextMeshProUGUI text2;

    private int score3;
    private TextMeshProUGUI text3;
    // Start is called before the first frame update
    void Start()
    {
        score1 = global_variables.score1;
        GameObject player1 = this.transform.GetChild(1).gameObject;
        text1 = player1.GetComponent<TMPro.TextMeshProUGUI>();
        text1.text = string.Format("Player 1 : {0}", score1);

        score2 = global_variables.score2;
        GameObject player2 = this.transform.GetChild(2).gameObject;
        text2 = player2.GetComponent<TMPro.TextMeshProUGUI>();
        text2.text = string.Format("Player 2 : {0}", score2);

        score3 = global_variables.score3;
        GameObject ai = this.transform.GetChild(3).gameObject;
        text3 = ai.GetComponent<TMPro.TextMeshProUGUI>();
        text3.text = string.Format("AI : {0}", score3);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
