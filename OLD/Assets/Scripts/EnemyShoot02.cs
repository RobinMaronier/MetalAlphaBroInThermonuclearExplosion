using UnityEngine;
using System.Collections;

public class EnemyShoot02 : MonoBehaviour
{
    public GameObject bullet;
    public float shotDelay = 1.0f;
    private bool readyToShoot = false;

    void Start()
    {
        Invoke("Shoot", shotDelay);
    }
    
    void Shoot()
    {
        if (GetComponent<AudioSource>() && !GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
        Instantiate(bullet, transform.position, transform.rotation);
        Invoke("Shoot", shotDelay);
    }
}
