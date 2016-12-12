using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour
{
    public GameObject gib = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (gib != null && col.tag == "Wall")
        {
            Instantiate(gib, transform.position + new Vector3(0.3f, 0.8f, 0), gib.transform.rotation);
            Destroy(gameObject);
        }
    }
}
