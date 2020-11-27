﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileManager : MonoBehaviour
{
    [SerializeField] ProjectileScriptableObject projectileScriptableObject;
    [SerializeField] int amount;
    [SerializeField] float speed;
    private Rigidbody2D rb;
    private Vector2 bounds;
    private SpriteRenderer sr;
    int time = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        sr.sprite = projectileScriptableObject.sprite;
        rb.velocity = new Vector2(speed, speed); 

    }

    // Update is called once per frame
    void Update()
    {
        
        if(time >= 400)
        {
            Destroy(this.gameObject);
            time = 0;
        }
       
        
    }
    private void FixedUpdate()
    {
        time++;
        Debug.Log(time);
    }
    
}
