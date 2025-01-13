using UnityEngine;

public class Wall : MonoBehaviour
{
    public LayerMask bulletMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((bulletMask & (1 << collision.collider.gameObject.layer)) != 0)
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
