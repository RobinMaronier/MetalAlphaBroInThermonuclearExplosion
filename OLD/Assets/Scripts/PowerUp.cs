using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        GameObject.FindGameObjectWithTag("Player").SendMessage("PowerUp");
        Destroy(gameObject);
    }
}
