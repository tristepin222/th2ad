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
    
    private const int MAXSLOTS = 6;
    private int capacity = 0;
    private bool found = false;
  

    public Inventory(){
        itemList = new List<Item>();

    
        
     }

    
    
     public void AddInventory(Item itemName){
         capacity = itemList.Count-1;
         if(itemList.Count > MAXSLOTS ){
             
            throw new InventoryFullException();
         }
         
             if(itemList.Count == 0){
                 
                  itemList.Add(itemName);  
                 
                  
             }else{
                 
             for(int i = 0; i < itemList.Count;i++){
                 
                
              
              
                 if(itemList[i].GetString() == itemName.GetString()){

                     
                     found = true;
                    
                    if((itemList[i].amount < itemName.getMaxAmount()))
                    {
                     
                     
                          if(!itemList[i].maxedOut){
                       itemList[i].amount += itemName.amount;
                          }
                 
                 
                       
                    }else if(!itemList[i].maxedOut){
                        
                        if(itemList.Count >= MAXSLOTS ){
             
                            throw new InventoryFullException();
                        }
                        
                      
                       itemList[i].maxedOut = true;
                          itemList.Add(itemName);
                            
                        break;
                          
                    }
                    
                    
                 }
                 
             }
             if(!found){
                
                 found = false;
                if(itemList.Count >= MAXSLOTS ){
             
                            throw new InventoryFullException();
                        }
                        
                       
                          itemList.Add(itemName);
                          
                      
             }
                         
             
            
             }
             
             
        OnItemListChanged.Invoke(this, EventArgs.Empty);
         
       
    }

    public List<Item> getItemList(){
       return itemList;
    }
    public override string ToString()
    {
        return base.ToString() + OnItemListChanged.ToString();
    }
}

