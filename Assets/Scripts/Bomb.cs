using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;
    public float shotDelay = 1.0f;

    private bool readyToShoot = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.P) && readyToShoot)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            readyToShoot = false;
            Invoke("ResetReadyToShoot", shotDelay);
        }
	}

    void ResetReadyToShoot()
    {

        readyToShoot = true;
    }
}
