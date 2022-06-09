using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
/**
	This class is the implementation of the timer used in the game and how it is handled in it
*/
public class Timer : MonoBehaviour
{
    private float initTimerValue;
    private Text timerText;
    private bool running = true;
    public static float timeRemaining;
    public Slider slider;
    float maxMinutes = PlayerSettings.time;
    public GameManager gameManager;

    public static bool paused = true;
    public GameObject[] players;

    public void Awake() {
        initTimerValue = Time.time;
    }

    // Start is called before the first frame update
    public void Start() {
        running = true;
        timeRemaining = maxMinutes * 60;
        timerText = GetComponent<Text>();
        DisplayTime(timeRemaining-1); 
        //timerText.text = string.Format("Time : {0:00}:{1:00}", 0, 0);
        slider.value = timeRemaining;
    }

    // Update is called once per frame
    public void Update() {

        if (!paused)
        {
            if (running)
            {

                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;

                    DisplayTime(timeRemaining);
                    slider.value = timeRemaining;
                }

                else
                {
                    GameObject root = this.transform.parent.gameObject.transform.parent.gameObject;
                    GameObject cellulos = root.transform.GetChild(1).gameObject;
                    global_variables.score1 = cellulos.transform.GetChild(0).gameObject.GetComponent<public_variables>().score;
                    global_variables.score2 = cellulos.transform.GetChild(1).gameObject.GetComponent<public_variables>().score;
                    global_variables.score3 = cellulos.transform.GetChild(2).gameObject.GetComponent<public_variables>().score;


                    int highest_score = Mathf.Max(global_variables.score1, global_variables.score2, global_variables.score3);
                    paused = true;
                    foreach (GameObject player in players) {
                        bool isWinner = (player.GetComponent<public_variables>().score == highest_score) ? true : false;
                        Debug.Log(isWinner);
                        player.GetComponent<CommonBehaviour>().SetEndGameColor(isWinner);
                    }
                    Thread.Sleep(7000);
                    SceneManager.LoadScene(2);
                    running = false;
                }
            }
        }
        
    }

    void DisplayTime(float timeToDisplay) {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("Time : {0:00}:{1:00}", minutes, seconds);
    }
}
