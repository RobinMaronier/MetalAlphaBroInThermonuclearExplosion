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
	private int currentExplosionNumber = 1;

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
			float shortDelay = 0.018f;
            GameObject.Find("HUDSkill0" + currentSkillNumber).GetComponent<SpriteRenderer>().sprite = empty;
            readyToShoot = false;
			Invoke("LaunchBombAfterDelay", shortDelay);
			shortDelay += 0.018f;
			Invoke("LaunchBombAfterDelay", shortDelay);
			shortDelay += 0.018f;
			Invoke("LaunchBombAfterDelay", shortDelay);
			shortDelay += 1f;
			Invoke ("ResetReadyToShoot", shortDelay);
            --currentSkillNumber;
        }
    }

    void ResetReadyToShoot()
    {
        readyToShoot = true;
    }

	void LaunchBombAfterDelay() {
		Vector3 currentPosition = transform.position;
		Vector3 currentExplosion;

		if (currentExplosionNumber == 1) {
			currentExplosion = new Vector3 (-2f, currentPosition.y + 4f, currentPosition.z);
			Instantiate(gib, currentExplosion, gib.transform.rotation);
		} else if (currentExplosionNumber == 2) {
			currentExplosion = new Vector3 (1f, currentPosition.y + 3f, currentPosition.z);
			Instantiate(gib, currentExplosion, gib.transform.rotation);
		} else {
			currentExplosion = new Vector3(3.5f, currentPosition.y + 4f, currentPosition.z);
			Instantiate(gib, currentExplosion, gib.transform.rotation);
			currentExplosionNumber = 0;
		}
		currentExplosionNumber++;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			float distance = (currentExplosion - obj.transform.position).sqrMagnitude;
			if (distance < 3)
			{
				obj.GetComponent<GibOnTrigger>().life -= 3;
				obj.GetComponent<GibOnTrigger>().CheckDeath();
			}
		}
	}
}
