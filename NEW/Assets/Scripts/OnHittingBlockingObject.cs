using UnityEngine;
using System.Collections;

public class OnHittingBlockingObject : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter()
    {
        Debug.Log("Kiwi");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    /*void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kiwi");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }*/
}
