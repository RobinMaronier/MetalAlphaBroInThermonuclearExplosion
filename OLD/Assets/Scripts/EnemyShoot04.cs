using UnityEngine;
using System.Collections;

public class EnemyShoot04 : MonoBehaviour {
	public GameObject bullet;
	public float shotDelay = 3.0f;
	public int mainDestiation = 1;

	private bool readyToShoot = false;
	private bool waitingToShoot = false;


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
			Invoke("ResetReadyToShoot", Random.Range(shotDelay -0.5f, shotDelay + 0.5f));
		}
	}

	void ResetReadyToShoot()
	{
		readyToShoot = true;
		waitingToShoot = false;
	}
}