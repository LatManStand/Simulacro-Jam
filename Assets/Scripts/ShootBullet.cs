using System.Collections;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public float lifeTime = 1.0f;
    public float damage = 1.0f;
    
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
