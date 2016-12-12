using UnityEngine;
using System.Collections;

public class DestroySlash : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        Invoke("KillSlash", 0.15f);
    }

    void KillSlash()
    {
        Destroy(gameObject);
    }
}
