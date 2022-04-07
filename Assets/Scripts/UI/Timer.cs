using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
	This class is the implementation of the timer used in the game and how it is handled in it
*/
public class Timer : MonoBehaviour
{
    private float initTimerValue;
    private Text timerText;
    private bool running = true;
    public float timeRemaining;
    public Slider slider;
    public float maxMinutes = 1;
    public GameManager gameManager;

    public void Awake() {
        initTimerValue = Time.time;
    }

    // Start is called before the first frame update
    public void Start() {
        running = true;
        timeRemaining = maxMinutes * 60;
        timerText = GetComponent<Text>();
        timerText.text = string.Format("Time : {0:00}:{1:00}", 0, 0);
        slider.value = timeRemaining;
    }

    // Update is called once per frame
    public void Update() {

        if (running) {

            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;

                DisplayTime(timeRemaining);
                slider.value = timeRemaining;
            }

            else {
                GameObject root = this.transform.parent.gameObject.transform.parent.gameObject;
                GameObject cellulos = root.transform.GetChild(1).gameObject;
                Debug.Log("child : " + cellulos.name);
                global_variables.score1 = cellulos.transform.GetChild(0).gameObject.GetComponent<public_variables>().score;
                SceneManager.LoadScene(2);
                running = false;
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
