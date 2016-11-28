using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (transform.Find("MenuBip").GetComponent<AudioSource>())
            {
                transform.Find("MenuBip").GetComponent<AudioSource>().Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.Return))
        {
            if (transform.Find("MenuSelect").GetComponent<AudioSource>())
            {
                transform.Find("MenuSelect").GetComponent<AudioSource>().Play();
            }
        }
    }
}
