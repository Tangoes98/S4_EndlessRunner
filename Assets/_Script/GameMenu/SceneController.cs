using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    //scene index
    int s;
    private void Awake()
    {
        s = SceneManager.GetActiveScene().buildIndex;
        if (s == 1)
        {
            turnOffMenu();
            Time.timeScale = 0;
        }
    }

    public void RunGame()
    {
        Time.timeScale = 1;
        //GameObject.Find("Instructions").SetActive(false);

    }

    public void gameButton()
    {
        // when button pressed goto gamescene1

        if (s != 0)
        {
            SceneManager.LoadScene(s);
            Time.timeScale = 1;
            turnOffMenu();
        }
        else
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 0;

        }

    }

    public void quitGame()
    {
        // when Exit pressed quit the game
        Application.Quit();
        Debug.Log("Exit Game");
    }

    public static void InGameMenu()
    {
        var p_inGameMune = GameObject.Find("P_InGameMenu");
        p_inGameMune.transform.GetChild(0).gameObject.SetActive(true);
    }

    void turnOffMenu()
    {
        GameObject.Find("InGameMenu").SetActive(false);
    }

}
