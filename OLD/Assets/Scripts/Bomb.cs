using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;
    public float shotDelay = 1.0f;
    public int bombNumber = -1;
    public bool isMain = false;
    public Sprite full;
    public Sprite empty;

    private bool readyToShoot = true;
    private int currentBombNumber;

    // Use this for initialization
    void Start ()
    {
        currentBombNumber = bombNumber;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.P) && readyToShoot && bombNumber != -1 && currentBombNumber > 0)
        {
            if (isMain == true)
            {
                GameObject.Find("HUDBomb0" + currentBombNumber).GetComponent<SpriteRenderer>().sprite = empty;
            }
            Instantiate(bomb, transform.position, transform.rotation);
            readyToShoot = false;
            Invoke("ResetReadyToShoot", shotDelay);
            --currentBombNumber;
        }
	}

    void ResetReadyToShoot()
    {

        readyToShoot = true;
    }
}
