using UnityEngine;
using System.Collections;

public class DestroyAfterDelay : MonoBehaviour
{
    public float delay = 0.5f;

	// Use this for initialization
	void Start () {
        Invoke("DestroyAfterDelayFunction", Random.Range(delay, delay + 0.2f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DestroyAfterDelayFunction()
    {
        Destroy(gameObject);
    }
}
