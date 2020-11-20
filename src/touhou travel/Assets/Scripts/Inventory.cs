using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Inventory
{

public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    private GameObject inventoryUI;
    
   
    public Inventory(){
        itemList = new List<Item>();

    
        
     }

    
    
     public void AddInventory(Item itemName){
        itemList.Add(itemName);
        OnItemListChanged.Invoke(this, EventArgs.Empty);
        Debug.Log(OnItemListChanged);
       
    }

    public List<Item> getItemList(){
       return itemList;
    }
    public override string ToString()
    {
        return base.ToString() + OnItemListChanged.ToString();
    }
}

