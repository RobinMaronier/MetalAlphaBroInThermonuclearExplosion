using UnityEngine;
using System.Collections;

public class PlayerDeathOnImpact : MonoBehaviour
{
    public int healthPoints = 5;
    public GameObject gib = null;
    public GameObject objectToDestroy = null;
    public Sprite full;
    public Sprite lessFull;
    public Sprite empty;

    private int currentHealthPoint;

    // Use this for initialization
    void Start()
    {
        if (healthPoints != -1)
            currentHealthPoint = healthPoints;
        if (objectToDestroy == null)
        {
            objectToDestroy = gameObject;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        GetComponent<AudioSource>().Play();
        gameObject.GetComponentInParent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Invoke("Flashing", 0.05f);
        if (currentHealthPoint -1 <= 0)
        {
            GameObject.Find("HUDHp01").GetComponent<SpriteRenderer>().sprite = empty;
            GameObject.Find("HUDHp02").GetComponent<SpriteRenderer>().sprite = empty;
            --currentHealthPoint;
            if (gib != null)
            {
                Instantiate(gib, transform.position, gib.transform.rotation);
            }
            Destroy(objectToDestroy);
        }
        else
        {
            GameObject.Find("HUDHp0" + currentHealthPoint).GetComponent<SpriteRenderer>().sprite = lessFull;
            if (currentHealthPoint < healthPoints)
                GameObject.Find("HUDHp0" + (currentHealthPoint + 1)).GetComponent<SpriteRenderer>().sprite = empty;
            --currentHealthPoint;
        }
    }

    void Flashing()
    {
        gameObject.GetComponentInParent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        Invoke("FlashingNext", 0.05f);
    }

    void FlashingNext()
    {
        gameObject.GetComponentInParent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Invoke("GoBackToNormalAlpha", 0.05f);
    }

    void GoBackToNormalAlpha()
    {
        gameObject.GetComponentInParent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
