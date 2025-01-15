using UnityEngine;

public class PlayerController : SkillSystem
{
    public static PlayerController instance;

    public float speed = 5f;
    public float currentSpeed = 5f;


    public int health = 100;
    public int maxHealth = 100;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalMove, verticalMove);

        rb.linearVelocity = movement * currentSpeed;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Game Over
            Debug.Log("Game Over");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EnemyBullet"))
        {
            TakeDamage(1);
            Destroy(collision.collider.gameObject);
        }
    }
}
