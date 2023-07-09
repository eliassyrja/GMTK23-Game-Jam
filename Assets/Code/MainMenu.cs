using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsGameObject;
    private AudioManager audioManager;
    
    void Start()
    {
        gameObject.SetActive(true);
        audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.PlayClip("MenuMusic", Camera.main.transform, true);
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
