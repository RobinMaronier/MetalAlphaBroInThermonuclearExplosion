using UnityEngine;
using System.Collections;

public class LookAtNearestEnemy : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float nearestDistance = Mathf.Infinity;
        GameObject nearestEnemey = null;
	    foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float distance = (transform.position - obj.transform.position).sqrMagnitude;
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemey = obj;
            }
        }
        if (nearestEnemey != null)
        {
            transform.rotation = Quaternion.LookRotation(nearestEnemey.transform.position - transform.position, Vector3.back);
        }
	}
}
