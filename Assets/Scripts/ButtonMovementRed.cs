using UnityEngine;
using System.Collections;

public class ButtonMovementRed : MonoBehaviour
{
    public Sprite Up;
    public Sprite Down;

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
    }

    // Update is called once per frame
    void Update()
    {
        //Fire
        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.M))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Down;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
        }
    }
}
