﻿using UnityEngine;
using System.Collections;

public class PlayerKatana : MonoBehaviour
{
    public GameObject slash;

    private bool melee = false;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L)) && melee == false)
        {
            melee = true;
            anim.SetBool("melee", true);
            Invoke("MeleeDelay", 0.5f);
            Invoke("InstantiateSlash", 0.15f);
        }
    }

    void InstantiateSlash()
    {
        GetComponent<AudioSource>().Play();
        Instantiate(slash, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
    }

    void MeleeDelay()
    {
        melee = false;
        anim.SetBool("melee", false);
    }
}
