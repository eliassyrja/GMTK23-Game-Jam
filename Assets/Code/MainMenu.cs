using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(true);
    }

    public void StartGame()
	{
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}

    public void QuitGame()
    {
        Application.Quit();
    }
}
