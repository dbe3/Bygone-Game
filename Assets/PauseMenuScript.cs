using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PausePanel;
    bool paused;

    private void Awake()
    {
        paused = false;
        Time.timeScale = 1;
    }

    void Start()
    {
        paused = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                PauseGame();
            }
            else if (paused == true)
            {
                UnpauseGame();
            }      
        }
    }

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        paused = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        paused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
