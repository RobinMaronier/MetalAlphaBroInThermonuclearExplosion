using UnityEngine;
using System.Collections;

public class ButtonMovementBigRed : MonoBehaviour
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
        if (Input.GetKey(KeyCode.P))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Down;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
        }
    }
}
