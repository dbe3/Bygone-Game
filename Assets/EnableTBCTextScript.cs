using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableTBCTextScript : MonoBehaviour
{
    public GameObject TBCText;

    public void TBCEnable()
    {
        TBCText.SetActive(true);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
