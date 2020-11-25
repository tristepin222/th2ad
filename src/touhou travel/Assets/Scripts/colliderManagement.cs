using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManagement : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject canva;



    [SerializeField] PlayerManagament player;
    [SerializeField] private Transform textException;
    [SerializeField] ItemScriptableObject itemScriptableObject;
    [SerializeField] int amount;
    [SerializeField] int maxAmount;
    private Inventory selfIventory;
    private KeyCode e = KeyCode.E;
    private Canvas Interact;
    private Item item;

    private void Awake()
    {
        canva = GameObject.FindGameObjectWithTag("Interact");
        canva.SetActive(false);
    }

    void Start()
    {
        item = new Item { itemScriptableObject = this.itemScriptableObject, amount = this.maxAmount, maxAmount = this.maxAmount, maxedOut = false };
        textException.gameObject.SetActive(false);
        Interact = Canvas.FindObjectOfType<Canvas>();
        selfIventory = new Inventory();
        
        selfIventory.AddInventory(item);
    
        

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
                    selfIventory.RemoveInventory(item);
                    player.GetInventory().AddInventory(item);

                    

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
