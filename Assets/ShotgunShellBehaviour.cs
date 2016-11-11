using UnityEngine;
using System.Collections;

public class ShotgunShellBehaviour : MonoBehaviour
{
    public GameObject gunFire;
    public GameObject shotgunParent;

    private bool readyToShoot = true;
    private int currentBombNumber;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K) && shotgunParent.GetComponent<PlayerShootShotgun>().readyToShoot == true)
        {
            Invoke("ShootingWithRandomDelay", Random.Range(0.0f, 0.2f));
        }
    }

    void ShootingWithRandomDelay()
    {
        Instantiate(gunFire, transform.position, transform.rotation);
    }
}
