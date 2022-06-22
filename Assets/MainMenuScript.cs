using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public GameObject Instructions;

    public void StartGame()
    {
        SceneManager.LoadScene("DemoLevel");
    }

    public void ShowInstructions()
    {
        Instructions.SetActive(true);
    }

    public void HideInstructions()
    {
        Instructions.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
