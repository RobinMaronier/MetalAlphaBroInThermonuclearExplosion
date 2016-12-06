using UnityEngine;
using System.Collections;

public class EnemyShoot01 : MonoBehaviour
{
    public GameObject bullet;
    public float shotDelay = 1.0f;
    private bool readyToShoot = false;
    private bool waitingToShoot = false;

    // Update is called once per frame
    void Update()
    {
        if (readyToShoot == true)
        {
            if (GetComponent<AudioSource>() && !GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            Instantiate(bullet, transform.position, transform.rotation);
            readyToShoot = false;
        }
        else if (waitingToShoot == false)
        {
            waitingToShoot = true;
            Invoke("ResetReadyToShoot", Random.Range(shotDelay - 0.5f, shotDelay + 0.5f));
        }
    }

    void ResetReadyToShoot()
    {
        readyToShoot = true;
        waitingToShoot = false;
    }
}
