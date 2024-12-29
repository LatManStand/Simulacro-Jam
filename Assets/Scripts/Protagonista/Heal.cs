using System;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Heal : MonoBehaviour
{
    public PlayerController player;

    public int healing = 10;

    public float cooldown = 0.2f;
    private float cooldownTimer;
    private bool isOnCooldown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOnCooldown)
        {
            if (player.health + healing > player.maxHealth)
            {
                player.health = player.maxHealth;
            }
            else
            {
                player.health += healing;
            }
            isOnCooldown = true;
            cooldownTimer = 0f;
        }

        if (isOnCooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldown)
            {
                isOnCooldown = false;
                cooldownTimer = 0f;
            }
        }
    }
}
