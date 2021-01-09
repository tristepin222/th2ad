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
    private GameObject Interact;
    private Item item;
    private bool entered;


    private void Awake()
    {
        
        
        
    }

    void Start()
    {
        
        textException.gameObject.SetActive(false);
        Interact = GameObject.FindGameObjectWithTag("Interact");
        Interact.SetActive(false);
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
