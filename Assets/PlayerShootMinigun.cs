using UnityEngine;
using System.Collections;

public class PlayerShootMinigun : MonoBehaviour
{
    public GameObject[] HUD;
    public GameObject bullet;
    public float bulletNumber = 60.0f;
    public float shotDelay = 0.05f;
    public float reloadDelay = 3.5f;
    public Sprite full;
    public Sprite lessFull;
    public Sprite lessEmpty;
    public Sprite empty;
    public bool readyToShoot = true;

    private float currentBulletNumber;
    private int tmp = 0;

    void Start()
    {
        if (bulletNumber != -1)
            currentBulletNumber = bulletNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.K)) && readyToShoot)
        {
            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().Play();
            }
            Instantiate(bullet, transform.position, transform.rotation);
            readyToShoot = false;
            if (bulletNumber != -1 && (currentBulletNumber/5.0f) - 1.0f < 0)
            {
                HUD[0].GetComponent<SpriteRenderer>().sprite = empty;
                HUD[1].GetComponent<SpriteRenderer>().sprite = empty;
                Invoke("ResetReadyToShootAfterReload", reloadDelay);
            }
            else if (bulletNumber != -1)
            {
                tmp = 0;
                while (tmp < 12)
                {
                    if (tmp <= (int)(currentBulletNumber / 5.0f) - 1)
                        HUD[tmp].GetComponent<SpriteRenderer>().sprite = full;
                    else if (tmp == (int)(currentBulletNumber / 5.0f))
                        HUD[tmp].GetComponent<SpriteRenderer>().sprite = lessFull;
                    else if (tmp == (int)(currentBulletNumber / 5.0f) + 1)
                        HUD[tmp].GetComponent<SpriteRenderer>().sprite = lessEmpty;
                    else
                        HUD[tmp].GetComponent<SpriteRenderer>().sprite = empty;
                    ++tmp;
                }
                currentBulletNumber--;
                Invoke("ResetReadyToShoot", shotDelay);
            }
        }
        if (Input.GetKey(KeyCode.K))
        {
            CharacterController controller = transform.parent.GetComponent<CharacterController>();
            controller.Move(Vector3.down * 2 * Time.deltaTime);
        }
    }

    void ResetReadyToShoot()
    {

        readyToShoot = true;
    }

    void ResetReadyToShootAfterReload()
    {
        tmp = 0;
        currentBulletNumber = 60;
        while (tmp < 12)
        {
            HUD[tmp].GetComponent<SpriteRenderer>().sprite = full;
            ++tmp;
        }
        readyToShoot = true;
    }
}
