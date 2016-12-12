using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject HUD;
    public GameObject bullet;
    public int bulletNumber = -1;
    public float shotDelay = 0.2f;
    public float reloadDelay = 1.0f;
    public Sprite full;
    public Sprite lessFull;
    public Sprite lessEmpty;
    public Sprite empty;

    private bool readyToShoot = true;
    private int currentBulletNumber;
    private string tmp = "";
  
    void Start()
    {
        if (bulletNumber != -1)
        currentBulletNumber = bulletNumber;
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
            Instantiate(bullet, transform.position, transform.rotation);
            readyToShoot = false;
            if (bulletNumber != -1 && currentBulletNumber -1 == 0)
            {
                GameObject.Find("HUDBullet01").GetComponent<SpriteRenderer>().sprite = empty;
                GameObject.Find("HUDBullet02").GetComponent<SpriteRenderer>().sprite = empty;
                --currentBulletNumber;
                Invoke("ResetReadyToShootAfterReload", reloadDelay);
            }
            else if (bulletNumber != -1)
            {
                if ((currentBulletNumber) < 10)
                    tmp = "0";
                else
                    tmp = "";
                GameObject.Find("HUDBullet" + tmp + currentBulletNumber).GetComponent<SpriteRenderer>().sprite = lessFull;
                if ((currentBulletNumber + 1) < 10)
                    tmp = "0";
                else
                    tmp = "";
                if (currentBulletNumber < bulletNumber)
                GameObject.Find("HUDBullet" + tmp + (currentBulletNumber + 1)).GetComponent<SpriteRenderer>().sprite = lessEmpty;
                if ((currentBulletNumber + 2) < 10)
                    tmp = "0";
                else
                    tmp = "";
                if (currentBulletNumber + 1 < bulletNumber)
                    GameObject.Find("HUDBullet" + tmp + (currentBulletNumber + 2)).GetComponent<SpriteRenderer>().sprite = empty;
                --currentBulletNumber;
                Invoke("ResetReadyToShoot", shotDelay);
            }
            else
            {
                Invoke("ResetReadyToShoot", shotDelay);
            }
        }
	}

    void ResetReadyToShoot()
    {

        readyToShoot = true;
    }

    void ResetReadyToShootAfterReload()
    {
        while (currentBulletNumber < bulletNumber)
        {
            ++currentBulletNumber;
            if ((currentBulletNumber) < 10)
                tmp = "0";
            else
                tmp = "";
            GameObject.Find("HUDBullet" + tmp + (currentBulletNumber)).GetComponent<SpriteRenderer>().sprite = full;
        }
        readyToShoot = true;
    }
}
