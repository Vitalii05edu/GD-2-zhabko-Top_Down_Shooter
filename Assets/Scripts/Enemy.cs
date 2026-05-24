using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float health, maxHealth = 2f;

    public AudioClip deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(player.gameObject);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            if (deathSound != null)
            {
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
            }

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddPoints(10);
            }

            Destroy(gameObject);
        }
    }
}
