using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsGameObject;
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

    public void OpenOptions()
    {
        gameObject.SetActive(false);
        optionsGameObject.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsGameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
