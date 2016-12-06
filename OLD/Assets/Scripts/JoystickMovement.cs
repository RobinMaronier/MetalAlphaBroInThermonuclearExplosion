using UnityEngine;
using System.Collections;

public class JoystickMovement : MonoBehaviour
{
    public Sprite Middle;
    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;
    public Sprite UpLeft;
    public Sprite DownRight;
    public Sprite DownLeft;
    public Sprite UpRight;


    // Use this for initialization
    void Start ()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Middle;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)) &&
            (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = UpLeft;
        }
        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) &&
                 (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DownRight;
        }
        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) &&
                 (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DownLeft;
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) &&
            (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = UpRight;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Right;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Down;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Middle;
        }
    }
}
