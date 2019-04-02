﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            Rigidbody2D player = hit.GetComponent<Rigidbody2D>();
            //if (player != null)
            //{
                player.isKinematic = false;
                Vector2 difference = (player.transform.position*2) - transform.position;
                difference = difference.normalized*thrust;
                player.AddForce(difference, ForceMode2D.Impulse);
                player.isKinematic = true;
            //}
        }
    }
}
