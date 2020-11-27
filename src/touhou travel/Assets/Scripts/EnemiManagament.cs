using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiManagament : MonoBehaviour
{
    private LifeManagament life;
    public EventHandler hit;
    void Awake()
    {
        life = new LifeManagament(2);
    }

    public void OnHit()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ProjectilePlayer")
        {
            Destroy(other.gameObject);
            life.reduceLife(1);
        }
    }
    private void Update()
    {
        if(life.lifeAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
