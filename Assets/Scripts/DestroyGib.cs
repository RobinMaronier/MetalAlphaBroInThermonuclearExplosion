using UnityEngine;
using System.Collections;

public class DestroyGib : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Invoke("DestroyAfterDelay", 1.0f);
    }

    void DestroyAfterDelay()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
