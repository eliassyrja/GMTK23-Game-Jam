using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreGameObject;

    void Start()
    {
        gameObject.SetActive(false);
        scoreText = scoreGameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Setup(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString("F0");
    }
}
