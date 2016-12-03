using UnityEngine;
using System.Collections;

public class EnemyShoot03 : MonoBehaviour {
	public GameObject bullet;
	public float shotDelay = 5.0f;
	public int mainDestiation = 1;

	private bool readyToShoot = false;
	private bool waitingToShoot = false;
	private bool isMoving = false;
	private int i = 0;

	void Update()
	{
		if (readyToShoot == true)
		{
			if (GetComponent<AudioSource>() && !GetComponent<AudioSource>().isPlaying)
			{
				GetComponent<AudioSource>().Play();
			}
			Instantiate(bullet, transform.position, transform.rotation);
			readyToShoot = false;
		}
		else if (waitingToShoot == false)
		{
			waitingToShoot = true;
			Invoke("ResetReadyToShoot", Random.Range(shotDelay + 0.5f, shotDelay + 0.5f));
		}
	}

	void ResetReadyToShoot()
	{
		readyToShoot = true;
		waitingToShoot = false;
	}
}