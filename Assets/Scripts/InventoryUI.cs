using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    SlotUI[] slotUIs; // Array of all the SlotUI components

    // Connects all the SlotUI components with their respective slots
    public void ConnectSlotUIsToInventory (Player player) {

        slotUIs = GetComponentsInChildren<SlotUI>(); // This works, and we end up with 40 SlotUIs;

        // Relying on the fact that Unity retrieves the SlotUIs in the same order as they are in the hierarchy

        for (int i = 0; i < slotUIs.Length; i++) {
            Slot slot = player.inventory[i % player.inventorySize.x, (i / player.inventorySize.x)]; // Outside bounds
            SlotUI slotUI = slotUIs[i];
            slotUI.SetSlot(slot);
            slot.slotUI = slotUI;
        }

        player.UpdateInventoryUI(); // Not sure if I need this
    }
}