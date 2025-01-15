using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class Bomb : MonoBehaviour
{
    public GameObject bombPrefab;

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
            putBomb();
            isOnCooldown = true;
            cooldownTimer = 0f;
            UISystemManager.instance.DoBomb(cooldown);
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
    private void putBomb()
    {
        GameObject go = Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }
}
