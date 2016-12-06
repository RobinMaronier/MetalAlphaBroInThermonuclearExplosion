using UnityEngine;
using System.Collections;

public class LookAtNearestPlayer : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float nearestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PlayerHead"))
        {
            float distance = (transform.position - obj.transform.position).sqrMagnitude;
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPlayer = obj;
            }
        }
        if (nearestPlayer != null)
        {
            transform.rotation = Quaternion.LookRotation(nearestPlayer.transform.position - transform.position, Vector3.back);
        }
    }
}
