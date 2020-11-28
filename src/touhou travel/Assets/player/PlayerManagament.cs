﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManagament : MonoBehaviour
{
 
    [SerializeField] private UI_Inventory uiInventory;
    private Vector2 selfTransform;
    [SerializeField] private UI_Life uiLife;
    [SerializeField] ProjectileScriptableObject projectileScriptableObject;
    [SerializeField] int amount;
    [SerializeField] GameObject projectile;
    private static Inventory inventory;
    [SerializeField] int cooldownMax;
    [SerializeField] string typeName;
 [SerializeField] private  Collider2D collider2DC;
 private Type type;
private LifeManagament life;
    private GameObject canva;
    private ProjectileManagament projectileManagament;
    [SerializeField] GameObject projectilePreFab;
    [SerializeField] public float bulletSpeed;
    private int cooldown = 0;
    private Vector3 target;
    private KeyCode esc = KeyCode.Escape;
    [SerializeField] public GameObject player;
    [SerializeField] int bulletAmount;
    private  void Awake() {
      type = new Type(typeName);
        inventory = new Inventory();
        life = new LifeManagament(3);
        projectileManagament = new ProjectileManagament(projectileScriptableObject, amount);
    uiInventory.SetInventory(inventory);
        
    uiLife.setLifeUI(life);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }
    public Collider2D GetCollider2D()
    {
        return collider2DC;
    }
    void Start()
    {
        canva = GameObject.FindGameObjectWithTag("MainMenu");
         
        
    }
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        cooldown++;
        if (Input.GetKeyDown(esc))
        {
            
            canva.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            if (cooldown >= cooldownMax)
            {
                for (int i = 0; i < bulletAmount; i++)
                {
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    LaunchProjectile(direction, rotationZ, i);
                }
                cooldown = 0;
            }
        }

    }

    private void LaunchProjectile(Vector2 direction, float rotationZ, int offset)
    {
        
           
        
        GameObject b = Instantiate(projectile) as GameObject;
        float fOffset = 0.5f;
        if (offset >= 2)
        {
            b.transform.position = this.GetComponent<Transform>().position - new Vector3(fOffset, 0, 0) + new Vector3(0, fOffset, 0);
        }
        else if(offset >= 1)
        {
            b.transform.position = this.GetComponent<Transform>().position + new Vector3(fOffset, fOffset, 0);
        }
        else
        {
            b.transform.position = this.GetComponent<Transform>().position;
        }
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
    
    public LifeManagament GetLife()
    {
        return life;
    }
}

