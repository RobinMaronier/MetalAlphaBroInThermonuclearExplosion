using UnityEngine;
using System.Collections;

public class BaseLaserBehaviour : MonoBehaviour
{
    public float ShotDelay = 1.0f;

	// Use this for initialization
	void Start ()
    {
        Invoke("DestroyAfterDelay", ShotDelay);
    }

    void DestroyAfterDelay()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        gameObject.transform.position = player.transform.position + new Vector3(0.28f, 0.45f, 0);
    }
}
