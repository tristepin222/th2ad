using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootManager : MonoBehaviour
{
    [SerializeField] ItemScriptableObject itemScriptableObject;
    [SerializeField] int maxAmount;
    [SerializeField] int amount;
    public Item item;
    private void Start()
    {

        item = new Item { itemScriptableObject = this.itemScriptableObject, amount = this.amount, maxAmount = this.maxAmount, maxedOut = false };
    }

    public Item GetItem()
    {
        return item;
    }
}
