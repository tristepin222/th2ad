using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagament : MonoBehaviour
{

[SerializeField] private UI_Inventory uiInventory; 
private Inventory inventory;
 private GameObject canva;
      private KeyCode e = KeyCode.E;
 
    private KeyCode esc = KeyCode.Escape;

    private Canvas Interact;
   private  void Awake() {
        
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
        inventory.AddInventory(new Item { itemType = Item.ItemType.Wood, amount = 3});
       
    }

    }

}

