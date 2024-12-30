using System.Collections;
using UnityEngine;

public class PulseArea : MonoBehaviour
{
    public float lifeTime = 2.0f;
    public float pulseVelocity = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    void Update()
    {
        float newScale = Time.deltaTime * this.pulseVelocity;
        this.transform.localScale += new Vector3(transform.localScale.x * newScale, transform.localScale.y * newScale,
            transform.localScale.z * newScale);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
