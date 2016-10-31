using UnityEngine;
using System.Collections;

public class DestroyOnImpact : MonoBehaviour
{
    public GameObject gib = null;

    // Use this for initialization
    void Start ()
    {
	
	}

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if (gib != null)
        {
            Instantiate(gib, transform.position + new Vector3(0.3f, 0.8f, 0), gib.transform.rotation);
        }
        Destroy(gameObject);
    }
}
