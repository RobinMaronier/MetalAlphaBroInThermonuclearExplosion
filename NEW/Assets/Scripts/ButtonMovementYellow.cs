using UnityEngine;
using System.Collections;

public class ButtonMovementYellow : MonoBehaviour
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
        if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.L))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Down;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
        }
    }
}
