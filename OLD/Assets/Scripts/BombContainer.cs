using UnityEngine;
using System.Collections;

public class BombContainer : MonoBehaviour
{
    public float shotDelay = 1.0f;
    public int bombNumber = -1;
 
    private bool readyToShoot = true;
    private int currentBombNumber;

    // Use this for initialization
    void Start()
    {
        currentBombNumber = bombNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) && readyToShoot && bombNumber != -1 && currentBombNumber > 0)
        {
            if (GetComponent<AudioSource>() && !GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            readyToShoot = false;
            Invoke("ResetReadyToShoot", shotDelay);
            --currentBombNumber;
        }
    }

    void ResetReadyToShoot()
    {

        readyToShoot = true;
    }
}
