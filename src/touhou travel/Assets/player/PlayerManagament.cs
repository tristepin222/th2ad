using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManagament : MonoBehaviour
{

[SerializeField] private UI_Inventory uiInventory; 
private Inventory inventory;
 private GameObject canva;
      private KeyCode e = KeyCode.E;
 
 [SerializeField] private Transform textException;
 
    private KeyCode esc = KeyCode.Escape;

    private Canvas Interact;
   private  void Awake() {
        textException.gameObject.SetActive(false);
    inventory = new Inventory();
    
    uiInventory.SetInventory(inventory);
    }
    void Start()
    {
        canva = GameObject.FindGameObjectWithTag("MainMenu");
         Interact = Canvas.FindObjectOfType<Canvas>();
        
    }
    void Update()
    {
        if (Input.GetKeyDown(esc))
        {
            
            canva.SetActive(true);
        }
        if(Input.GetKeyDown(e) && Interact.enabled == true){
        try{
            textException.gameObject.SetActive(false);
            inventory.AddInventory(new Item { itemType = Item.ItemType.Wood, amount = 1, maxAmount = 15});
            inventory.AddInventory(new Item { itemType = Item.ItemType.Spell, amount = 1, maxAmount = 2});
        }catch(FullObjectException){
         textException.gameObject.SetActive(true);
        
                   }
       
    }

    }

}

