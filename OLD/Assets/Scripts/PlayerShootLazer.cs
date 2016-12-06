using UnityEngine;
using System.Collections;

public class PlayerShootLazer : MonoBehaviour
{
    public GameObject lazer;
    public GameObject baseLazer;
    public float shotDelay = 0.2f;

    private bool readyToShoot = true;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.K)) && readyToShoot)
        {
            if (GetComponent<AudioSource>() && !GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            Instantiate(lazer, transform.position, transform.rotation);
            Instantiate(baseLazer, transform.position + new Vector3(0.25f, 0.4f, 0), transform.rotation);
            readyToShoot = false;
            Invoke("ResetReadyToShoot", shotDelay);
        }
    }

    void ResetReadyToShoot()
    {

        readyToShoot = true;    
    }
}
