using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemiManagament : MonoBehaviour
{
    [SerializeField] PlayerManagament player;
    private LifeManagament life;
    public EventHandler hit;
    UnityEngine.Random rand;
   public Item item;
    void Awake()
    {
        life = new LifeManagament(2);
        rand = new UnityEngine.Random();
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
            player.GetLife().addLife(1);
        }
    }

    private void randomDrop()
    {
        int randInt = UnityEngine.Random.Range(0, 1);

        switch (randInt)
        {
            default:
            case  0:  item = new Item(); break;
            case 1:  item = new Item(); break;
        }
    }
}
