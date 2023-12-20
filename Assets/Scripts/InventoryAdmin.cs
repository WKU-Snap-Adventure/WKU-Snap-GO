using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAdmin : MonoBehaviour
{
    // This script contained in Canvas
    public GameObject inventorySlot;
    public Transform ItemSlotContainer;
    public ItemManager itemManager;
    Inventory inventory;

    InventorySlot[] slots;
    
    // Start is called before the first frame update
    void Update()
    {
        
    }
    
    public void AddSlot(Item item)
    {
        GameObject newSlot = Instantiate(inventorySlot);

        if (ItemSlotContainer != null)
        {
            RectTransform newSlotTransform = newSlot.GetComponent<RectTransform>();

            newSlotTransform.SetParent(ItemSlotContainer, false);

            newSlotTransform.localScale = Vector3.one;
        }
        else
        {
            Debug.LogWarning("ItemSlotContainer not assigned. The InventorySlot will be a root-level object.");
        }

        InventorySlot newInventorySlot = newSlot.GetComponent<InventorySlot>();

        newInventorySlot.LoadItem(item);
    }


// For every slot, try to load item refering to the inventory item list.

    public void ClearSlot(Item item){
        slots = ItemSlotContainer.GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item.name == item.name)
                slots[i].ClearSlot();
        }
    }

    public void IncreaseItemAmount(Item item) {
        slots = ItemSlotContainer.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item.name == item.name){
                slots[i].itemAmount++;
                slots[i].amount.text = slots[i].itemAmount.ToString();
            }
        }
    }

    public void SetSlot(ItemData itemData)
    {
        GameObject newSlot = Instantiate(inventorySlot);

        if (ItemSlotContainer != null)
        {
            // Generate new slot
            RectTransform newSlotTransform = newSlot.GetComponent<RectTransform>();

            newSlotTransform.SetParent(ItemSlotContainer, false);

            newSlotTransform.localScale = Vector3.one;

            InventorySlot newInventorySlot = newSlot.GetComponent<InventorySlot>();

            // Fill in the item info (Amount, item, sprite)
            newInventorySlot.itemAmount = itemData.amount;

            newInventorySlot.amount.enabled = true;
            newInventorySlot.amount.text = newInventorySlot.itemAmount.ToString();

            // Call the static methods and fit in the item 
            newInventorySlot.item = ItemManager.GetItem(itemData.name);

            // Search and fit in the item sprite
            if (ItemManager.itemIconDictionary.ContainsKey(itemData.name))
            {
                newInventorySlot.icon.sprite = ItemManager.GetItemIcon(itemData.name);
                newInventorySlot.icon.enabled = true;
            }
            else
            {
                Debug.LogError("Item not found in dictionary: " + itemData.name);
            }
        }
        else
        {
            Debug.LogWarning("ItemSlotContainer not assigned. The InventorySlot will be a root-level object.");
        }
    }


}
