using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManagament : MonoBehaviour
{

[SerializeField] private UI_Inventory uiInventory; 

[SerializeField] private UI_Life uiLife; 
private Inventory inventory;
private LifeManagament life;
 private GameObject canva;
 public Item item{get; set;}
      private KeyCode e = KeyCode.E;
 
 [SerializeField] private Transform textException;
 
    private KeyCode esc = KeyCode.Escape;

    private Canvas Interact;
   private  void Awake() {
        textException.gameObject.SetActive(false);
        inventory = new Inventory();
        life = new LifeManagament(3);
    
    uiInventory.SetInventory(inventory);
    uiLife.setLifeUI(life);
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
          
           inventory.AddInventory(new Item{itemType = Item.ItemType.Wood, amount = 1, maxAmount = 16, maxedOut = false});
           life.addLife(1);
        }catch(FullObjectException){
         textException.gameObject.SetActive(true);
        
                   }
       
    }

    }

    

}

