﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // Start is called before the first frame update
    public enum ItemType{
        Spell,
        HealthPotion,
        Coin,
        Wood,
        Rock,
    }

    // Update is called once per frame
    public ItemType itemType;
    public int amount {get; set;}
    public  int maxAmount;
    public bool maxedOut;
   
    public string GetString(){
        switch(itemType){
            default:
            case ItemType.Spell : return "Spell";
            case ItemType.HealthPotion : return "HealthPotion";
            case ItemType.Coin : return "Coin";
            case ItemType.Wood : return "Wood";
            case ItemType.Rock : return "Rock";
        }
        
    }
    
    public int GetAmount(){
        return amount;
    }
    public int getMaxAmount(){
        return maxAmount;
    }
}
