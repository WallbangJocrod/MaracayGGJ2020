﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonGrua : MonoBehaviour
{
    public GameObject grua, camara, player, panel;

    private Rigidbody2D RB2D;

    private bool activado, activado2;

    private FollowTarget follow;

    private Player scriptPlayer;

    public float timer;

    public float ShakeMagnitude, ShakeDuration;


    void Start()
    {
        RB2D = grua.GetComponent<Rigidbody2D>();

        follow = camara.GetComponent<FollowTarget>();

        scriptPlayer = player.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (activado2)
        {
            RB2D.isKinematic = false;
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                follow.gameObject.GetComponent<FollowTarget>().GetDamage(ShakeDuration, ShakeMagnitude, 0,0);
                scriptPlayer.enabled = true;
                panel.SetActive(false);
                activado2 = false;
            }
        }
    }

    private void Update()
    {
        if(activado && Input.GetKeyDown(KeyCode.E))
        {
            activado2 = true;
            activado = false;

            scriptPlayer.enabled = false;
            scriptPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activado = true;
        }
    }
}
