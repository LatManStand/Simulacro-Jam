using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject targetPlayer;

    public float speed = 2;
    public int maxHealth = 5;
    public int health = 5;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        health = maxHealth;
        if (targetPlayer == null)
        {
            //targetPlayer = GameObject.FindWithTag("Player");
            targetPlayer = PlayerController.instance.gameObject;
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    public virtual void Move()
    {
        if (targetPlayer && rb)
        {
            rb.MovePosition(transform.position + (targetPlayer.transform.position - transform.position).normalized * speed * Time.deltaTime);
        }
    }
    public virtual void Look()
    {
        if (targetPlayer)
        {
            transform.up = targetPlayer.transform.position - transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerBullet"))
        {
            health--;
            if (health <= 0)
            {
                EnemyGenerator.instance.KillEnemy(this);
            }
            Destroy(collision.collider.gameObject);
        }
    }
}