using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerSystems;

public class HealthBar : MonoBehaviour
{

    int health = 15;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {

        health = GameObject.FindWithTag("Player").GetComponent<PlayerStatsBehaviour>().PlayerStatsInstance.Health;

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
    }

}
