using UnityEngine;
using System.Collections;

public class ButtonMovementBlue : MonoBehaviour
{
    public Sprite Up;
    public Sprite Down;

    // Use this for initialization
    void Start ()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Fire
        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.K))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Down;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
        }
    }
}
