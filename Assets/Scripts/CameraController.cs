using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float speed = 3.0f;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        //Handle playerspeed
        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha1))
        {
            speed = 1.5f;
        }
        else
        {
            speed = 3f;
        }
    }
}
