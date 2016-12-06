using UnityEngine;
using System.Collections;

public class SpawnWave : MonoBehaviour
{
    public GameObject powerUp = null;
    public GameObject objectToSpawn;
    public float spawnDelay = 1.0f;
    public int numberOfEnemies;

    private int enemyCount;

    // Use this for initialization
    void Start()
    {
        enemyCount = numberOfEnemies;
        Spawn();
    }

    void Update()
    {
        if (enemyCount <= 0)
        {
            if (transform.childCount <= 0)
            {
                if (powerUp != null)
                {
                    Instantiate(powerUp, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
    }

    void Spawn()
    {
        enemyCount--;
        GameObject instance = Instantiate(objectToSpawn, transform.position, transform.rotation) as GameObject; //Fait en sorte que les enemies soient des childs de lu spawner
        instance.transform.parent = transform;
        if (enemyCount > 0)
        {
            Invoke("Spawn", spawnDelay);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
