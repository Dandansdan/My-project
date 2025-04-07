using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryGrid;
    public bool messyInventory;

    private void Awake()
    {
        ConfigureInventory();
    }

    public void PlaceInInventory(UISlotHandler activeSlot, Item item)
    {
        activeSlot.item = item;
        activeSlot.icon.sprite = item.itemIcon;
        activeSlot.itemCountText.text = item.itemCount.ToString();
        activeSlot.icon.gameObject.SetActive(true);
        ConfigureInventory();
    }

    public void StackInInventory(UISlotHandler activeSlot, Item item)
    {
        if (activeSlot.item.itemID != item.itemID) { return; }

        activeSlot.item.itemCount += item.itemCount;
        activeSlot.itemCountText.text = activeSlot.item.itemCount.ToString();
        ConfigureInventory();
    }

    public void ClearItemSlot(UISlotHandler activeSlot)
    {
        activeSlot.item = null;
        activeSlot.icon.sprite = null;
        activeSlot.itemCountText.text = string.Empty;
        activeSlot.icon.gameObject.SetActive(false);
    }

    public void ConfigureInventory()
    {
        if (messyInventory) { return; }

        //Loop through each child of inventory grid
        //Rearrange by populated items

        List<Transform> uiSlots = new List<Transform>();
        for (int i = 0; i < inventoryGrid.transform.childCount; i++)
        {
            uiSlots.Add(inventoryGrid.transform.GetChild(i));
        }

        uiSlots.Sort((a, b) =>
        {
            UISlotHandler itemA = a.GetComponent<UISlotHandler>();
            UISlotHandler itemB = b.GetComponent<UISlotHandler>();

            bool hasItemA = itemA.item != null;
            bool hasItemB = itemB.item != null;

            return hasItemB.CompareTo(hasItemA);
        });

        for (int i = 0; i < uiSlots.Count; i++)
        {
            uiSlots[i].SetSiblingIndex(i);
        }
    }
}
