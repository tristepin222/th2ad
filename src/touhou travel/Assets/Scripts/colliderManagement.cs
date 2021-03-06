﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManagement : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private GameObject canva;



    [SerializeField] PlayerManagament player;
    [SerializeField] private bool invert;
    [SerializeField] private Transform textException;
    [SerializeField] private ItemScriptableObject itemScriptableObject;
    [SerializeField] private int amount;
    [SerializeField] private int maxAmount;
    [SerializeField] private int amountToAdd;
    [SerializeField] private bool deleteWhenEmpty;
    [SerializeField] private Collider2D collider2DC;
    private Inventory selfIventory;
    private KeyCode e = KeyCode.E;
    private GameObject Interact;
    private Item item;
    private bool entered;


    private void Awake()
    {
        if (player == null)
        {
            player = GlobalControl.Instance.player.GetComponent<PlayerManagament>();
        }
        if (textException == null)
        {
            textException = GlobalControl.Instance.ui_inventory.transform.Find("FullException");
        }
        Interact = GameObject.FindGameObjectWithTag("Interact");
        if (Interact == null)
        {
            Interact = GlobalControl.Instance.ui_interact;
        }
        Interact.SetActive(false);
        selfIventory = new Inventory();

        
    }

    void Start()
    {
        if (player == null)
        {
            player = GlobalControl.Instance.player.GetComponent<PlayerManagament>();
        }
        if (textException == null)
        {
            textException = GlobalControl.Instance.ui_inventory.transform.Find("FullException");
        }
        textException.gameObject.SetActive(false);
        Interact = GameObject.FindGameObjectWithTag("Interact");
        if(Interact == null)
        {
            Interact = GlobalControl.Instance.ui_interact;
        }
        Interact.SetActive(false);
        selfIventory = new Inventory();

        if (!invert)
        {
            for (int i = 0; i < amountToAdd; i++)
            {
                item = new Item { itemScriptableObject = this.itemScriptableObject, item = itemScriptableObject.itemType, amount = this.maxAmount, maxAmount = this.maxAmount, maxedOut = false };
                selfIventory.AddInventory(item);
            }
            
        }
    
        

    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            entered = true;
            Interact.SetActive(true);
        }


    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            entered = false;
            Interact.SetActive(false);
        }
    }

   

    private void Update()
    {
       
        if (Input.GetKeyDown(e) && entered)
        {
            try
            {


                if (selfIventory.empty)
                {
                    throw new InventoryEmpty();
                }
                else
                {
                   
                    item = new Item { itemScriptableObject = this.itemScriptableObject, item = itemScriptableObject.itemType, amount = this.amount, maxAmount = this.maxAmount, maxedOut = false };
                    textException.gameObject.SetActive(false);
                    if(player.GetCollider2D().IsTouching(collider2DC)){
                 if(this.invert){
                        
                    player.GetInventory().RemoveInventory(item);
                    selfIventory.AddInventory(item);
                    this.invert = true;
                    }else{
                            if (selfIventory.empty != true)
                            {
                                selfIventory.RemoveInventory(item);
                                player.GetInventory().AddInventory(item);
                                this.invert = false;
                                if(deleteWhenEmpty == true)
                                {
                                    GameObject.Destroy(this.gameObject);
                                }
                            }

                    }
                        
                    }

                }
                

            }
            catch (InventoryFullException)
            {
                textException.gameObject.SetActive(true);

            }
            catch (InventoryEmpty)
            {

            }


        }
    }


}
