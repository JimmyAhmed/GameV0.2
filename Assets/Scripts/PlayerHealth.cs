using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text health_TXT;
    Slider healthSlider;

    private float Health;
    private const float MAX_HEALTH = 100;

    private void Start()
    {
        healthSlider = FindObjectOfType<Slider>();
        Health = MAX_HEALTH;
    }

    public virtual void DecreaseHealth(int amountOfHealth)
    {
        Health -= amountOfHealth;
        healthSlider.value = Health;
        health_TXT.text = Health.ToString();

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
