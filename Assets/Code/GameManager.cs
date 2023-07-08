using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score;
    private bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 10f;
    }

    public void Restart()
	{
        SceneManager.LoadScene(0, LoadSceneMode.Single);
	}

    public float GetScore()
	{
        return score;
	}
    public bool IsRunning()
	{
        return isRunning;
	}

    public void SetGameOver()
	{
        isRunning = false;
	}
}
