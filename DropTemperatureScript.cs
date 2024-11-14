using UnityEngine;

public class TemperatureController : MonoBehaviour
{
    public float startingBodyTemperature = 100f;
    private float currentBodyTemperature;
    private bool isCold = false;
    private bool isDead = false;
    private float temperatureDecreaseRate = 1f;
    private float decreaseTimer = 20f;

    void Start()
    {
        currentBodyTemperature = startingBodyTemperature;
        InvokeRepeating("DecreaseTemperature", 0f, decreaseTimer);
    }

    void Update()
    {
        if (!isDead)
        {
            if (currentBodyTemperature <= 0)
            {
                isDead = true;
                IsDead();
            }
        }
    }

    void DecreaseTemperature()
    {
        if (!isDead)
        {
            if (!isCold)
            {
                currentBodyTemperature -= temperatureDecreaseRate;
                Debug.Log("Temperature decreased by 1. Current temperature: " + currentBodyTemperature);
            }
        }
    }

    void IsDead()
    {
        Debug.Log("Character is dead!");
    }
}