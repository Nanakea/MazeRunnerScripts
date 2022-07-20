using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winLooseScript2 : MonoBehaviour
{
    private GUIStyle guiStyle = new GUIStyle();
    string message = "";

    private bool isDead = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player1")
        {
            message = "Player 2 Win\n Press R to restart.\n Press ESC to quit.";
            isDead = true;
            Time.timeScale = 0;
        }
        else if (collider.gameObject.tag == "Player2")
        {
            message = "Player 1 Win\n Press R to restart.\n Press ESC to quit.";
            isDead = true;
            Time.timeScale = 0;
        }
    }

    private void OnGUI()
    {
        guiStyle.fontSize = 30;
        GUI.Label(new Rect(Screen.width / 3, Screen.height / 2, 300, 50), message, guiStyle);
        GUI.backgroundColor = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isDead)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    /*private void OnGUI()
    {
        OnTriggerEnter
        {
            OnGUI().Label(new Rect(Screen.width / 2, Screen.height / 2, 200, 50), "逃げました！");
        }
    }*/
}
