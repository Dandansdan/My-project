using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager instance;

    public Item heldItem;
    public Item GetHeldItem { get { return heldItem; } }

    private void Awake()
    {
        instance = this;
    }

    public void UpdateHeldItem(UISlotHandler activeSlot)
    {
        var activeItem = activeSlot.item;

        if (heldItem != null && activeItem != null && heldItem.itemID == activeItem.itemID)
        {
            activeSlot.inventoryManager.StackInInventory(activeSlot, heldItem);
            heldItem = null;
            return;
        }

        if (activeSlot.item != null)
        {
            activeSlot.inventoryManager.ClearItemSlot(activeSlot);
        }
        if (heldItem != null)
            activeSlot.inventoryManager.PlaceInInventory(activeSlot, heldItem);

        heldItem = activeItem;
    }

    public void PickupFromStack(UISlotHandler activeSlot)
    {
        if (heldItem != null && heldItem.itemID != activeSlot.item.itemID) { return; }

        if (heldItem == null)
        {
            heldItem = activeSlot.item.Clone();
            heldItem.itemCount = default;
        }
        heldItem.itemCount++;

        activeSlot.item.itemCount--;
        activeSlot.itemCountText.text = activeSlot.item.itemCount.ToString();

        if (activeSlot.item.itemCount <= 0)
        {
            activeSlot.inventoryManager.ClearItemSlot(activeSlot);
        }
    }
}
