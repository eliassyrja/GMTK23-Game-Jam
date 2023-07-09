using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreGameObject;

    void Start()
    {
        gameObject.SetActive(true);
    }

    public void Setup(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString("F0");
    }

    public void StartGame()
	{
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}
}
