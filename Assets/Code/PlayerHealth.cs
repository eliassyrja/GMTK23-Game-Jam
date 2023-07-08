using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private TextMeshProUGUI healthText;

    [SerializeField] private GameObject healthGameObject;
    [SerializeField] private float health;

    // Start is called before the first frame update
    void Start()
    {
        healthText = healthGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
    }
}
