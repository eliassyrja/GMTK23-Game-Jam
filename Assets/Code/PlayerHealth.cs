using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private TextMeshProUGUI healthText;

    [SerializeField] private GameObject healthGameObject;
    [SerializeField] private float health;
    [SerializeField] private float healthLossSpeed;

    // Start is called before the first frame update
    void Start()
    {
        healthText = healthGameObject.GetComponent<TextMeshProUGUI>();
        InvokeRepeating("IncreaseHealthLossSpeed", 10, 10);
    }

    void FixedUpdate()
    {
        healthText.text = health.ToString("F0");
        if (!gameObject.GetComponent<BloodSuckingAction>().IsSucking())
        {
            health -= healthLossSpeed;
        }
    }

    void IncreaseHealthLossSpeed()
    {
        healthLossSpeed += 0.01f;
    }

    public float GetHealth()
    {
        return health;
    }
}
