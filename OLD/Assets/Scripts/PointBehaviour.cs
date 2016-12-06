using UnityEngine;
using System.Collections;

public class PointBehaviour : MonoBehaviour
{
    public float speed = 1.0f;
    public float lifeTime = 1.0f;

    // Use this for initialization
    void Start ()
    {
        Invoke("DestroyAvterDelay", lifeTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void DestroyAvterDelay()
    {
        Destroy(gameObject);
    }
}
