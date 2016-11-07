using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnDelay = 1.0f;

	// Use this for initialization
	void Start ()
    {
        Invoke("Spawn", spawnDelay);
	}
	
	void Spawn()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        Invoke("Spawn", spawnDelay);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
