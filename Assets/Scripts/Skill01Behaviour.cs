using UnityEngine;
using System.Collections;

public class Skill01Behaviour : MonoBehaviour
{
    public float shotDelay = 1.0f;
    public int skillNumber = -1;
	public GameObject gib = null;
    public Sprite full;
    public Sprite empty;

    private bool readyToShoot = true;
    private int currentSkillNumber;
	private int currentExplosion = 1;

    // Use this for initialization
    void Start ()
    {
        currentSkillNumber = skillNumber;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.O) && readyToShoot && skillNumber != -1 && currentSkillNumber > 0)
        {
			float shortDelay = 0;
            GameObject.Find("HUDSkill0" + currentSkillNumber).GetComponent<SpriteRenderer>().sprite = empty;
            readyToShoot = false;
			Invoke("LaunchBombAfterDelay", shortDelay);
			shortDelay += 0.018f;
			Invoke("ShotLazerAfterDelay", shortDelay);
			shortDelay += 0.018f;
			Invoke("LaunchBombAfterDelay", shortDelay);
			shortDelay += 0.018f;
			Invoke("LaunchBombAfterDelay", shortDelay);
            --currentSkillNumber;
        }
    }

    void ResetReadyToShoot()
    {
        readyToShoot = true;
    }

	void LaunchBombAfterDelay() {
		if (currentExplosion == 1) {
			Instantiate(gib, transform.position, gib.transform.rotation);
		} else if (currentExplosion == 2) {
			Instantiate(gib, transform.position, gib.transform.rotation);
		} else if (currentExplosion == 3) {
			Instantiate(gib, transform.position, gib.transform.rotation);
		} else {
			Instantiate(gib, transform.position, gib.transform.rotation);
			currentExplosion = 0;
		}
		currentExplosion++;
	}
}
