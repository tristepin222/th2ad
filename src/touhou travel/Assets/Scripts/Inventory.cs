using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{

    private GameObject inventoryUI;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryUI = GameObject.FindGameObjectWithTag("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void AddInventory(string itemName = "missigno!"){
        GameObject slot = new GameObject();
        slot.name = "slot";
           slot.transform.SetParent(inventoryUI.transform);
            Text item = slot.AddComponent<Text>();
            item.text = itemName;
           Debug.Log(item);
    }
}
