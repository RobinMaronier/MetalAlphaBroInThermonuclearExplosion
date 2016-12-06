using UnityEngine;
using System.Collections;

public class PlayerShootSniper : MonoBehaviour
{
    public GameObject[] HUD;
    public GameObject bullet;
    public int bulletNumber = 12;
    public float shotDelay = 1.0f;
    public float reloadDelay = 2.0f;
    public Sprite full;
    public Sprite lessFull;
    public Sprite lessEmpty;
    public Sprite empty;
    public bool readyToShoot = true;

    private int currentBulletNumber;
    private int tmp = 0;

    void Start()
    {
        if (bulletNumber != -1)
            currentBulletNumber = bulletNumber;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        float delay = 0.0f;

        if ((Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.K)) && readyToShoot)
        {
            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().Play();
            }
            while (i < 5)
            {
                Invoke("ShootAfterDelay", delay);
                delay += 0.03f;
                ++i;
            }
            readyToShoot = false;
            if (bulletNumber != -1 && currentBulletNumber - 3 <= 0)
            {
                HUD[0].GetComponent<SpriteRenderer>().sprite = empty;
                HUD[1].GetComponent<SpriteRenderer>().sprite = empty;
                HUD[2].GetComponent<SpriteRenderer>().sprite = empty;
                HUD[3].GetComponent<SpriteRenderer>().sprite = empty;
                currentBulletNumber -= 3;
                Invoke("ResetReadyToShootAfterReload", reloadDelay);
            }
            else if (bulletNumber != -1)
            {
                HUD[currentBulletNumber - 1].GetComponent<SpriteRenderer>().sprite = empty;
                HUD[currentBulletNumber - 2].GetComponent<SpriteRenderer>().sprite = lessEmpty;
                HUD[currentBulletNumber - 3].GetComponent<SpriteRenderer>().sprite = lessFull;
                tmp = currentBulletNumber;
                while (tmp < 12)
                    HUD[tmp++].GetComponent<SpriteRenderer>().sprite = empty;
                currentBulletNumber -= 3;
                Invoke("ResetReadyToShoot", shotDelay);
            }
            else
            {
                Invoke("ResetReadyToShoot", shotDelay);
            }
        }
    }

    void ShootAfterDelay()
    {
        Instantiate(bullet, transform.position + new Vector3(0.26f, 0.4f, 0), transform.rotation);
    }

    void ResetReadyToShoot()
    {

        readyToShoot = true;
    }

    void ResetReadyToShootAfterReload()
    {
        currentBulletNumber = 0;
        while (currentBulletNumber < 12)
        {
            ++currentBulletNumber;
            HUD[currentBulletNumber - 1].GetComponent<SpriteRenderer>().sprite = full;
        }
        readyToShoot = true;
    }
}
