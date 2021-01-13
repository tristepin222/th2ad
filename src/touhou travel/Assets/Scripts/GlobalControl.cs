﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GlobalControl : MonoBehaviour
{
   
    public static GlobalControl Instance;
    public LifeManagament life;
    public Transform v;
    public Inventory inventory;
    public GameObject ui_life;
    public GameObject ui_inventory;
    public GameObject vc;
    public GameObject player;

    public Vector3 v3;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(vc);
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(ui_life);
            DontDestroyOnLoad(ui_inventory);
            
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            Destroy(vc);
            Destroy(ui_life);
            Destroy(ui_inventory);
           
        }
    }
}
