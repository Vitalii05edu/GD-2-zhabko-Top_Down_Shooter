using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}