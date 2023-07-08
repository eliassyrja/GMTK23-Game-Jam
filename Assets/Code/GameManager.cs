using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score;
    [SerializeField] private GameObject mosqPrefab;
    [SerializeField] private float maxMosqAmount;
    [SerializeField] private float spawnBuffer;

    private float mosqAmount = 0f;
    private bool gameRunning;
    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
        score = 0f;
        InvokeRepeating(nameof(SpawnMosquito), 0, 3);
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
        return gameRunning;
	}

    public void SetGameOver()
	{
        gameRunning = false;
	}
    
    public void ReduceMosquito()
    {
        mosqAmount -= 1;
    }

    private void SpawnMosquito()
    {
        if (mosqAmount < maxMosqAmount)
        {
            Debug.Log("moskerino");
            Instantiate(mosqPrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-3.75f, 3.75f), 0), Quaternion.identity);
            mosqAmount += 1;
        }
    }
}
