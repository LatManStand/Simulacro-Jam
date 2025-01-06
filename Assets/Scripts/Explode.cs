using System.Collections;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float lifeTime = 2.0f;
    public float explosionLifeTime= 0.2f;
    public float damage = 1.0f;

    public GameObject explosion;

    void Awake()
    {
        StartCoroutine(Explota());
    }

    private void dealDamage()
    {
        if (explosion != null)
        {
            explosion.SetActive(true);
        }
    }

    IEnumerator Explota()
    {
        yield return new WaitForSeconds(lifeTime);
        dealDamage();
        yield return new WaitForSeconds(explosionLifeTime);
        Destroy(gameObject);
    }
}
