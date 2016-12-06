using UnityEngine;
using System.Collections;

public class GibOnTrigger : MonoBehaviour
{
    public GameObject gib = null;
    public GameObject pointAnimation = null;
    public int life = 3;
    public int points = 0;
    Animator anim;

    private GameObject player = null;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col)
    {
        anim.SetBool("isTakingDamage", true);
        Invoke("IsNotTakingDamageAnymore", 0.5f);
        if (col.tag == "Knife")
            life -= 3;
        else if (col.tag == "Katana")
            life -= 6;
        else
            life--;
        CheckDeath();
	}

    void Update()
    {
    }

    public void CheckDeath()
    {
        if (life <= 0)
        {
            if (gib != null)
            {
                Instantiate(gib, transform.position, gib.transform.rotation);
            }
            if (pointAnimation != null)
            {
                Instantiate(pointAnimation, transform.position, pointAnimation.transform.rotation);
            }
            if (player)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                player.transform.Find("PlayerScore").GetComponent<playerScore>().AddToScoreThenDisplay(points);
            }
            Destroy(gameObject);
        }
    }

    void IsNotTakingDamageAnymore()
    {
        anim.SetBool("isTakingDamage", false);
    }
}
