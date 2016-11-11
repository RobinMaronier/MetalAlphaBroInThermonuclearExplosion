using UnityEngine;
using System.Collections;

public class Skill04Behaviour : MonoBehaviour
{
    public GameObject ultraLazer = null;
    public float shotDelay = 1.0f;
    public int skillNumber = -1;
    public Sprite full;
    public Sprite empty;

    private bool readyToShoot = true;
    private int currentSkillNumber;
    private float shortDelay;
    private int i;

    // Use this for initialization
    void Start()
    {
        currentSkillNumber = skillNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O) && readyToShoot && skillNumber != -1 && currentSkillNumber > 0)
        {
            shortDelay = 0;
            i = 0;
            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().Play();
            }
            while (i < 25)
            {
                Invoke("ShotLazerAfterDelay", shortDelay);
                shortDelay += 0.018f;
                ++i;
            }
            GameObject.Find("HUDSkill0" + currentSkillNumber).GetComponent<SpriteRenderer>().sprite = empty;
            readyToShoot = false;
            Invoke("ResetReadyToShoot", shotDelay);
            --currentSkillNumber;
        }
    }

    void ResetReadyToShoot()
    {
        readyToShoot = true;
    }

    void ShotLazerAfterDelay()
    {
        Instantiate(ultraLazer, transform.position + new Vector3(0.65f, -0.3f, 0), transform.rotation);
    }
}
