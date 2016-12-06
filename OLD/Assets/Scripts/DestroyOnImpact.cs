using UnityEngine;
using System.Collections;

public class DestroyOnImpact : MonoBehaviour
{
    public GameObject gib = null;
    public float xFromSource = 0.3f;
    public float yFromSource = 0.8f;

    // Use this for initialization
    void Start ()
    {
	
	}

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if (gib != null)
        {
            Instantiate(gib, transform.position + new Vector3(xFromSource, yFromSource, 0), gib.transform.rotation);
        }
        Destroy(gameObject);
    }
}
