using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    private GameObject player;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            if (Time.time > spawnTime)
            {
                Spawn();
                spawnTime = Time.time + timeBetweenSpawn;
            }
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(enemy, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}