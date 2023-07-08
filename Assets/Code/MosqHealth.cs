using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqHealth : MonoBehaviour
{
    [SerializeField] private float mosquitoHealth;

    // Start is called before the first frame update
    void Start()
    {
        mosquitoHealth = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetMosquitoHealth()
    {
        return mosquitoHealth;
    }

    public void SetMosquitoHealth(float newHealth)
    {
        mosquitoHealth = newHealth;
    }
}
