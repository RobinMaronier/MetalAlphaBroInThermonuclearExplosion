using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int initialHealth = 3;
    public GameObject hitEffect;
    public GameObject deathEffect;
    private int currentHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = initialHealth;
	}

    void OnTriggerEnter()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
