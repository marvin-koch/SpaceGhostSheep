using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class winner : MonoBehaviour
{
    private TextMeshProUGUI text1;
    private string winner_text;

    // Start is called before the first frame update
    void Start()
    {
        if (global_variables.score1 > global_variables.score2) {
            winner_text = "Winner : Player 1";
        } else if (global_variables.score1 == global_variables.score2) {
            winner_text = "It's a draw!";
        } else {
            winner_text = "Winner : Player 2";
        }
        text1 = this.GetComponent<TMPro.TextMeshProUGUI>();
        text1.text = string.Format(winner_text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
