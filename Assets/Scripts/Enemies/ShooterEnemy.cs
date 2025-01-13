using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{

    public float minDistanceToPlayer;
    public Vector3 targetPosition;
    public float shootDelay;
    public float shootCooldown;
    public List<Transform> cannons;
    public GameObject bulletPrefab;
    public float bulletLifetime;
    public float bulletSpeed;


    public override void Init()
    {
        base.Init();
        InvokeRepeating(nameof(StartShooting), shootCooldown, shootCooldown + 2 * shootDelay);
    }

    public override void Move()
    {
        if (targetPlayer)
        {
            targetPosition = targetPlayer.transform.position + (transform.position - targetPlayer.transform.position).normalized * minDistanceToPlayer;
            rb.MovePosition(transform.position + (targetPosition - transform.position).normalized * speed * Time.deltaTime);
        }
    }

    public void StartShooting()
    {
        Shoot();
        Invoke(nameof(Shoot), shootDelay);
        Invoke(nameof(Shoot), shootDelay * 2);
    }

    public void Shoot()
    {
        foreach (Transform t in cannons)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = t.position;
            bullet.transform.rotation = t.rotation;
            bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletSpeed * t.up;
            bullet.transform.parent = EnemyGenerator.instance.bulletsParent;
            Destroy(bullet, bulletLifetime);
        }
    }

    private void OnDestroy()
    {
        CancelInvoke(nameof(StartShooting));
        CancelInvoke(nameof(Shoot));
    }
}
