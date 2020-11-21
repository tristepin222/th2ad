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
    
    private const int MAXSLOTS = 5;
    private int capacity = 0;
    private bool fullStack = false;
  
    public Inventory(){
        itemList = new List<Item>();

    
        
     }

    
    
     public void AddInventory(Item itemName){
         capacity = itemList.Count-1;
         if(itemList.Count > MAXSLOTS ){
             
            throw new InventoryFullException();
         }
         else
         {
             if(itemList.Count == 0){
                  itemList.Add(itemName);  
                 
                  capacity = 0;
             }else{
             for(int i = capacity; i < itemList.Count;i++){
                 
                
                 if(itemList[i].GetString() == itemName.GetString()){
                     
                    if(itemList[i].amount < itemName.getMaxAmount() )
                    {
                      
                       itemList[i].amount += itemName.amount;
                       
                    }else{
                        if(itemList.Count >= MAXSLOTS ){
             
                            throw new InventoryFullException();
                        }
                        
                          itemList.Add(itemName);
                          break;
                          
                    }
                    
                 }else{
                    
                     itemList.Add(itemName);
                      break;
                     
                 }
             }
             
            
             }
             
             
        OnItemListChanged.Invoke(this, EventArgs.Empty);
         }
       
    }

    public List<Item> getItemList(){
       return itemList;
    }
    public override string ToString()
    {
        return base.ToString() + OnItemListChanged.ToString();
    }
}

