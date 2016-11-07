using UnityEngine;
using System.Collections;

public class PlayerKnife : MonoBehaviour
{
    private bool melee = false;

	// Use this for initialization
	void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.L)) && melee == false)
        {
            melee = true;
            Invoke("MeleeDelay", 0.5f);
            Invoke("InstantiateSlash", 0.15f);
        }
    }

    void InstantiateSlash()
    {
        GetComponent<AudioSource>().Play();
    }

    void MeleeDelay()
    {
        melee = false;
    }
}
