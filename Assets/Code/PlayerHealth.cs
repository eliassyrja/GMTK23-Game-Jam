using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    private GameManager gm;

    [SerializeField] private GameObject healthGameObject;
    [SerializeField] private float health;
    [SerializeField] private float healthLossSpeed;

    public EndScreen endScreen;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        healthText = healthGameObject.GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(IncreaseHealthLossSpeed), 10, 10);
    }

    void FixedUpdate()
    {
		if (gm.IsRunning())
		{
            healthText.text = health.ToString("F0");
            if (!gameObject.GetComponent<BloodSuckingAction>().IsSucking())
            {
                health -= healthLossSpeed;
                if (health <= 0)
                {
                    healthText.text = "0";
                    StartCoroutine(DeathAndDestroy());
                    gm.SetGameOver();
                    gm.GetComponent<AudioManager>().PlayClip("DraculaDeath", gameObject.transform);
                    endScreen.Setup(gm.GetScore());
                }
            }
        }
    }

    void IncreaseHealthLossSpeed()
    {
        healthLossSpeed += 0.01f;
    }

    public float GetPlayerHealth()
    {
        return health;
    }

    public void SetPlayerHealth(float newHealth)
    {
        health += newHealth;
    }
    private IEnumerator DeathAndDestroy()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
