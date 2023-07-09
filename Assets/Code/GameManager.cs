using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inGameScoreText;
    [SerializeField] private TextMeshProUGUI inGameScore;
    [SerializeField] private float score;
    [SerializeField] private GameObject mosqPrefab;
    [SerializeField] private float maxMosqAmount;
    [SerializeField] private float spawnRate;

    private AudioManager audioManager;
    private float mosqAmount = 0f;
    private bool gameRunning;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.PlayClip("Track", Camera.main.transform, true);
        gameRunning = true;
        score = 0f;

        for (int i = 0; i < maxMosqAmount; i++)
        {
            SpawnMosquito();
        }
        InvokeRepeating(nameof(SpawnMosquito), 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
		if (gameRunning)
		{
            score += Time.deltaTime * 10f;
            inGameScore.text = score.ToString("F0");
        }
    }

    public void Restart()
	{
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}

    public float GetScore()
	{
        return score;
	}
    public bool IsRunning()
	{
        return gameRunning;
	}

    public void SetGameOver()
	{
        gameRunning = false;
        inGameScore.gameObject.SetActive(false);
        inGameScoreText.gameObject.SetActive(false);
    }
    
    public void ReduceMosquito()
    {
        mosqAmount -= 1;
    }

    private void SpawnMosquito()
    {
        if (mosqAmount < maxMosqAmount && gameRunning)
        {
            Debug.Log("moskerino");
            Instantiate(mosqPrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-3.75f, 3.75f), 0), Quaternion.identity);
            mosqAmount += 1;
        }
    }
}
