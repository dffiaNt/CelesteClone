﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    Rigidbody2D rd_breakplat;

    [SerializeField]
    private float time_to_break = 0.5f;
    [SerializeField]
    private float time_to_comeback = 2f;
    
    void Start()
    {
        rd_breakplat = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            Invoke("BreakPlatform", time_to_break);
            Invoke("BringBackPlat", time_to_comeback);
        }
    }

    void BreakPlatform()
    {
        this.gameObject.SetActive(false);
    }

    void BringBackPlat()
    {
        this.gameObject.SetActive(true);
    }
}
