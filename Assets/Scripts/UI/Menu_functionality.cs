using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_functionality : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        Button menu = button.GetComponent<Button>();
        menu.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick(){
        SceneManager.LoadScene(0);
    }
}
