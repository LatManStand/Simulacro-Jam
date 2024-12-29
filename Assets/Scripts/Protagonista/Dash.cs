using UnityEngine;

public class Dash : MonoBehaviour
{
    public PlayerController player;

    private float dashStart;
    private bool isDashing;
    public float dashSpeed = 20f;
    public float dashTime = 0.2f;

    public float cooldown = 0.2f;
    private float cooldownTimer;
    private bool isOnCooldown = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && !isOnCooldown)
        {
            isDashing = true;
            dashStart = Time.time;
            player.currentSpeed = dashSpeed;
            isOnCooldown = true;
            cooldownTimer = 0f;
        }

        if (isDashing)
        {

            if (Time.time >= dashStart + dashTime)
            {
                isDashing = false;

                player.currentSpeed = player.speed;
            }
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
