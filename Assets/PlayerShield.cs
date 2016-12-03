using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour {

	public int duration = 7;
	public int skillNumber = -1;

	private bool readyToShoot = true;
	private int currentSkillNumber;


	// Use this for initialization
	void Start () {
		currentSkillNumber = skillNumber;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.O) && readyToShoot && skillNumber != -1 && currentSkillNumber > 0) {
			if (GetComponent<SpriteRenderer>())
			{
				GetComponent<SpriteRenderer> ().enabled = true;
			}
			if (GetComponent<BoxCollider> ()) {
				GetComponent<BoxCollider> ().enabled = true;
			}
			readyToShoot = false;
			Invoke ("ResetReadyToShoot", duration);
			--currentSkillNumber;
		}
	}

	void ResetReadyToShoot() {
		readyToShoot = true;
		if (GetComponent<SpriteRenderer>())
		{
			GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (GetComponent<BoxCollider> ()) {
			GetComponent<BoxCollider> ().enabled = false;
		}
	}
}
