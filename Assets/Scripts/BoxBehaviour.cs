using UnityEngine;
using System.Collections;

public class BoxBehaviour : MonoBehaviour
{
    public Sprite brokenBox;
    public GameObject gib = null;
    public int healthPoint = 3;

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Knife")
            healthPoint -= 3;
        else if (col.tag == "Katana")
            healthPoint -= 6;
        else
            healthPoint--;
        if (healthPoint <= 0)
        {
            Instantiate(gib, transform.position, gib.transform.rotation);
            gameObject.GetComponent<SpriteRenderer>().sprite = brokenBox;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            Invoke("GoBackToNormalAlpha", 0.05f);
        }
    }

    void GoBackToNormalAlpha()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
