using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Restart_functionality : MonoBehaviour
{
    public Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        Button restart = button.GetComponent<Button>();
        restart.onClick.AddListener(TaskOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick() {
        SceneManager.LoadScene(1);
    }
}
