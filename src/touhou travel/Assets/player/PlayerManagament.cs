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





    private KeyCode esc = KeyCode.Escape;

    
   private  void Awake() {
      
        inventory = new Inventory();
        life = new LifeManagament(3);
    
    uiInventory.SetInventory(inventory);
        
    uiLife.setLifeUI(life);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }
    void Start()
    {
        canva = GameObject.FindGameObjectWithTag("MainMenu");
         
        
    }
    void Update()
    {
        
        if (Input.GetKeyDown(esc))
        {
            
            canva.SetActive(true);
        }
        

    }

    

}

