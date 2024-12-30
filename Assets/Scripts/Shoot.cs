using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float bulletVelocity = 1.0f;
    public float lifeTime = 1.0f;
    public GameObject shootDirection;
    public GameObject bulletPrefab;
    
    #region SimpleDamage
    public float damage = 1.0f;
    public float bulletSize = .25f;
    #endregion

    #region MegaDamage

    public float megaDamage = 10.0f;
    public float megaBulletSize = .45f;
    public float pressingTime = 1.5f;

    #endregion
    
    // Update is called once per frame
    private float _startTime = 0.0f;
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            _startTime = Time.time;
        }
        if(Input.GetKeyUp("k"))
        {
            if ((Time.time - _startTime) >= pressingTime)
            {        
                DoShoot(megaDamage, megaBulletSize);
            }
            else
            {
                // Simple shoot
                DoShoot(damage, bulletSize);
            }
        }   
    }

    private void DoShoot(float damage, float size)
    {
        GameObject go = Instantiate(bulletPrefab, shootDirection.transform.position, shootDirection.transform.rotation);
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection.transform.up * bulletVelocity, ForceMode2D.Impulse);
        go.GetComponent<ShootBullet>().lifeTime = lifeTime;
        go.GetComponent<ShootBullet>().damage = damage;
        go.transform.localScale = new Vector3(size, size, go.transform.localScale.z);
    }
}
