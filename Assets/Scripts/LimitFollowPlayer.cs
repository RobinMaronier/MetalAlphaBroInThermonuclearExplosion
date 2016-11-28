using UnityEngine;
using System.Collections;

public class LimitFollowPlayer : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object
    public float xAxis = 0;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    public void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (player)
        {
            transform.position = new Vector3(0.5f, player.transform.position.y, 0) + offset;
        }
    }

    public void CheckOffset()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }
}
