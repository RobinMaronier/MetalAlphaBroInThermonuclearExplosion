using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float shotDelay = 0.2f;
    private bool readyToShoot = true;
  
	// Update is called once per frame
	void Update ()
    {
	    if ((Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha3)) && readyToShoot)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            readyToShoot = false;
            Invoke("ResetReadyToShoot", shotDelay);
        }
	}

    void ResetReadyToShoot()
    {
        readyToShoot = true;
    }
}
