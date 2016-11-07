using UnityEngine;
using System.Collections;

public class GibOnTrigger : MonoBehaviour
{
    public GameObject gib = null;
    public int life = 3;
    Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter()
    {
        anim.SetBool("isTakingDamage", true);
        Invoke("IsNotTakingDamageAnymore", 0.5f);
        life--;
        if (life <= 0)
        {
            if (gib != null)
            {
                Instantiate(gib, transform.position, gib.transform.rotation);
            }
            //transform.parent.SendMessage("Dead", transform.position, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
	}

    void Update()
    {
        if (life <= 0)
        {
            if (gib != null)
            {
                Instantiate(gib, transform.position, gib.transform.rotation);
            }
            //transform.parent.SendMessage("Dead", transform.position, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }

    void IsNotTakingDamageAnymore()
    {
        anim.SetBool("isTakingDamage", false);
    }
}
