using System.Collections;
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
    [SerializeField] private Collider2D collider2DC;
    private Inventory selfIventory;
    private KeyCode e = KeyCode.E;
    private Canvas Interact;
    private Item item;
  


    private void Awake()
    {
        
        canva.SetActive(false);
        
    }

    void Start()
    {
        
        textException.gameObject.SetActive(false);
        Interact = Canvas.FindObjectOfType<Canvas>();
        selfIventory = new Inventory();

        if (!invert)
        {
            for (int i = 0; i < 2; i++)
            {
                item = new Item { itemScriptableObject = this.itemScriptableObject, amount = this.maxAmount, maxAmount = this.maxAmount, maxedOut = false };
                selfIventory.AddInventory(item);
            }
            
        }
    
        

    }


    private void OnTriggerEnter2D(Collider2D other) {
        
      canva.SetActive(true);
        


    }
    
    private void OnTriggerExit2D(Collider2D other) {
     canva.SetActive(false);
        
    }

   

    private void Update()
    {
       
        if (Input.GetKeyDown(e) && Interact.enabled == true)
        {
            try
            {


                if (selfIventory.empty)
                {
                    throw new InventoryEmpty();
                }
                else
                {
                   
                    item = new Item { itemScriptableObject = this.itemScriptableObject, amount = this.amount, maxAmount = this.maxAmount, maxedOut = false };
                    textException.gameObject.SetActive(false);
                    if(player.GetCollider2D().IsTouching(collider2DC)){
                 if(this.invert){
                        
                    player.GetInventory().RemoveInventory(item);
                    selfIventory.AddInventory(item);
                    this.invert = true;
                    }else{
                    
                    selfIventory.RemoveInventory(item);
                    player.GetInventory().AddInventory(item);
                    this.invert = false;

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
