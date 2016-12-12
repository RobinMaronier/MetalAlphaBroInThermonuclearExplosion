using UnityEngine;
using System.Collections;

public class BarrelRedBehaviour : MonoBehaviour
{
    public Sprite brokenBarrel;
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

    void OnTriggerEnter()
    {
        --healthPoint;
        if (healthPoint <= 0)
        {
            Instantiate(gib, transform.position, gib.transform.rotation);
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float distance = (transform.position - obj.transform.position).sqrMagnitude;
                if (distance < 3)
                {
                    obj.GetComponent<GibOnTrigger>().life -= 3;
                    obj.GetComponent<GibOnTrigger>().CheckDeath();
                }
            }
            /*foreach (GameObject obj in GameObject.FindGameObjectsWithTag("RedBarrel"))
            {
                float distance = (transform.position - obj.transform.position).sqrMagnitude;
                if (distance < 3)
                {
                    obj.GetComponent<BarrelRedBehaviour>().OnTriggerEnter();
                }
            }*/
            gameObject.GetComponent<SpriteRenderer>().sprite = brokenBarrel;
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
