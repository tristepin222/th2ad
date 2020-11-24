using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManagement : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject canva;



    [SerializeField] PlayerManagament player;
    [SerializeField] private Transform textException;
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
        item = new Item { itemType = Item.ItemType.HealthPotion, amount = 12, maxAmount = 12, maxedOut = false };
        textException.gameObject.SetActive(false);
        Interact = Canvas.FindObjectOfType<Canvas>();
        selfIventory = new Inventory();
        
        selfIventory.AddInventory(item);
    
        

    }


    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(canva);
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
                textException.gameObject.SetActive(false);

                player.GetInventory().AddInventory(item);
                selfIventory.RemoveInventory(item);
                
            }
            catch (FullObjectException)
            {
                textException.gameObject.SetActive(true);

            }

        }
    }


}
