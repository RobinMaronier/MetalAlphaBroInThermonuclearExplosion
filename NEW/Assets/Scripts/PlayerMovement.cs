using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 3.0f;
    private bool melee = false;

    Animator anim;

	// Use this for initialization
	void Start()
	{
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
        CharacterController controller = GetComponent<CharacterController>();
        bool left, right, up, down;

        //transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
		{
			controller.Move(Vector3.left * speed * Time.deltaTime);
            left = true;
        }
        else
        {
            left = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
            controller.Move(Vector3.right * speed * Time.deltaTime);
            right = true;
        }
        else
        {
            right = false;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
		{
            controller.Move(Vector3.up * speed * Time.deltaTime);
            up = true;
        }
        else
        {
            up = false;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
            controller.Move(Vector3.down * speed * Time.deltaTime);
            down = true;
        }
        else
        {
            down = false;
        }
        if (left == true || right == true || up == true || down == true)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
        //Handle playerspeed
        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.M))
        {
            speed = 1.5f;
        }
        else
        {
            speed = 3f;
        }
    }
}
