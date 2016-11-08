using UnityEngine;
using System.Collections;

public class Skill01Behaviour : MonoBehaviour
{
    public float shotDelay = 1.0f;
    public int skillNumber = -1;
    public Sprite full;
    public Sprite empty;

    private bool readyToShoot = true;
    private int currentSkillNumber;

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
}
