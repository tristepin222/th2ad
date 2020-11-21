using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
   
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private  void Awake() {
    itemSlotContainer = transform.Find("itemSlotContainer");
    itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    itemSlotTemplate.gameObject.SetActive(false);
    
    }
    public void SetInventory(Inventory inventory){
        this.inventory = inventory;
       
        this.inventory.OnItemListChanged += Inventory_OnItemListChanged;
       
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
      RefreshInventoryItems();
    }
    private void RefreshInventoryItems(){
        
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 75f;
        
        foreach(Transform child in itemSlotContainer){
        if (child == itemSlotTemplate) continue;
        Destroy(child.gameObject);
    }
        foreach(Item item in inventory.getItemList()){
           
           RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
           itemSlotRectTransform.gameObject.SetActive(true);
           itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
           Text textcontent = itemSlotRectTransform.Find("Text").GetComponent<Text>();
           Text amountContent = itemSlotRectTransform.Find("Amount").GetComponent<Text>();
           textcontent.text = item.GetString();
           amountContent.text = item.GetAmount().ToString();
           x++;
        }
    }
}
