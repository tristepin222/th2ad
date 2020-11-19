using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManagement : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject canva;
    private Inventory inventory;
  
    void Start()
    {
      canva = GameObject.FindGameObjectWithTag("Interact");
      canva.SetActive(false);
     
    }


    private void OnTriggerEnter2D(Collider2D other) {
   
      canva.SetActive(true);
      
      
    }
    
    private void OnTriggerExit2D(Collider2D other) {
     canva.SetActive(false);
    }
   
    
}
