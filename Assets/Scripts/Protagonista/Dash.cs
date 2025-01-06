using UnityEngine;

public class Dash : MonoBehaviour
{
    private Collider collider;

    private float dashStart;
    private bool isDashing;
    public float dashSpeed = 20f;
    public float dashTime = 0.2f;

    public float cooldown = 0.2f;
    private float cooldownTimer;
    private bool isOnCooldown = false;
    // Update is called once per frame

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && !isOnCooldown)
        {
            isDashing = true;
            dashStart = Time.time;
            PlayerController.instance.currentSpeed = dashSpeed;
            isOnCooldown = true;
            cooldownTimer = 0f;
            Debug.Log("hola");
            if(collider != null)
            {
                collider.enabled = false;
                Debug.Log("entro");
            }
        }

        if (isDashing)
        {

            if (Time.time >= dashStart + dashTime)
            {
                isDashing = false;

                PlayerController.instance.currentSpeed = PlayerController.instance.speed;
                if (collider != null)
                {
                    collider.enabled = true;
                }
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
