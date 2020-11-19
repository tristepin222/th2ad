using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private GameObject canva;
      private KeyCode e = KeyCode.E;
    private Inventory inventory;
    private KeyCode esc = KeyCode.Escape;

    private Canvas Interact;
    // Start is called before the first frame update
    void Start()
    {
        canva = GameObject.FindGameObjectWithTag("MainMenu");
         inventory = gameObject.AddComponent(typeof (Inventory)) as Inventory;
         Interact = Canvas.FindObjectOfType<Canvas>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(esc))
        {
            
            canva.SetActive(true);
        }
        if(Input.GetKeyDown(e) && Interact.enabled == true){
         Debug.Log("oui");
        inventory.AddInventory("cola");
         Debug.Log("non");
        
      }
    }

  
}
