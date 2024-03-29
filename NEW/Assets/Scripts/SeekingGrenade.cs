﻿using UnityEngine;
using System.Collections;

public class SeekingGrenade : MonoBehaviour
{
    public float initialVelocity = 10.0f;
    public float grenadeAccelerationForce = 10.0f;
    public float maxVelocity = 10.0f;
    private float maxSqrVelocity;

    private GameObject nearestEnemy;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * initialVelocity, ForceMode.VelocityChange);
        float nearestDistance = Mathf.Infinity;
        nearestEnemy = null;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float distance = (transform.position - obj.transform.position).sqrMagnitude;
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = obj;
            }
        }
        maxSqrVelocity = maxVelocity * maxVelocity;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        grenadeAccelerationForce += 100.0f;

        if (nearestEnemy != null)
        {
            transform.rotation = Quaternion.LookRotation(nearestEnemy.transform.position - transform.position, Vector3.back);
        }

        //Debug.Log ("I'M GOING: " + rigidbody.velocity.magnitude);


        GetComponent<Rigidbody>().AddForce(transform.forward * grenadeAccelerationForce * Time.deltaTime, ForceMode.Acceleration);

        //Debug.Log("I am now going: " + rigidbody.velocity.magnitude);

        if (GetComponent<Rigidbody>().velocity.magnitude > maxVelocity)
        {
            //Debug.Log ("I'M GOING: " + rigidbody.velocity.magnitude);

            //Debug.Log("I should be going: " + (rigidbody.velocity.normalized*maxVelocity).magnitude);

            //rigidbody.velocity = Vector3.zero;

            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxVelocity;

            //Debug.Log("I am now going: " + rigidbody.velocity.magnitude);
        }
    }
}
