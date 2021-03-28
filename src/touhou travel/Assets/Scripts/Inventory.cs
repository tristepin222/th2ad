using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Inventory
{

    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    private bool has_item = false;
    public bool empty;
    private const int MAXSLOTS = 6;

  


    public Inventory()
    {
        itemList = new List<Item>();



    }



    public void AddInventory(Item itemName)
    {
          bool found = false;

        if (itemList.Count >= MAXSLOTS)
        {

            throw new InventoryFullException();
        }

        if (itemList.Count == 0)
        {

            itemList.Add(itemName);


        }
        else
        {

            for (int i = 0; i < itemList.Count; i++)
            {




                if (itemList[i].GetString() == itemName.GetString())
                {


                    found = true;

                    if ((itemList[i].amount < itemName.getMaxAmount()))
                    {


                        if (!itemList[i].maxedOut)
                        {

                            itemList[i].amount += itemName.GetAmount();
                        }



                    }
                    else if (!itemList[i].maxedOut)
                    {

                        if (itemList.Count >= MAXSLOTS)
                        {

                            throw new InventoryFullException();
                        }


                        itemList[i].maxedOut = true;
                        itemList.Add(itemName);

                        break;

                    }


                }

            }
            if (!found)
            {

                found = false;
                if (itemList.Count >= MAXSLOTS)
                {

                    throw new InventoryFullException();
                }


                itemList.Add(itemName);


            }



        }

        if (OnItemListChanged != null)
        {
            OnItemListChanged.Invoke(this, EventArgs.Empty);

        }
    }

    public List<Item> getItemList()
    {
        return itemList;
    }
    public bool hasItem(string nameItemNeeded)
    {
        foreach(Item item in itemList)
        {
            string name = item.GetString();
            if(name == nameItemNeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }
    public override string ToString()
    {
        return base.ToString();
    }
    public void RemoveInventory(Item itemName)
    {
        bool found = false;
        Item itemInInventory = null;
        if (itemList.Count != 0)
        {
            empty = false;
            foreach(Item item in itemList)
            {
                
                if (!found)
                {

                    if (item.itemScriptableObject == itemName.itemScriptableObject)
                    {
                        
                        item.amount -= itemName.GetAmount();
                        found = true;
                        itemInInventory = item;
                        break;
                    }
                }
            }
            if (itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
                found = false;
            }

        }
        else
        {
            empty = true;
            throw new InventoryEmpty();
        }
        if (OnItemListChanged != null)
        {
            OnItemListChanged.Invoke(this, EventArgs.Empty);

        }

    }
}

