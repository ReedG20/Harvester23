using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    SlotUI[] slotUI; // Array of all the SlotUI components

    // Connects all the SlotUI components with their respective slots
    public void SetupInventory (Player player) {

        slotUI = GetComponentsInChildren<SlotUI>(); // Get the array of all the SlotUI components in the slot gameobjects
        for (int y = player.inventorySize.y; y > 0; y--) // Top to bottom
        {
            for (int x = 1; x <= player.inventorySize.x; x++) // Left to right
            {
                // (1, 5), (2, 5)... (7, 1), (8, 1)

                SetupInventoryExtension(new Vector2Int(x, y), player);
            }
        }

        // UpdateInventoryUI(); ?
    }
    void SetupInventoryExtension (Vector2Int currentPosition, Player player) { // Function because I need the break functionality to exit the nested loops
        foreach (var slotUI in slotUI) // Loop for every SlotUI component in the array 
        {
            if (slotUI.GetSlot() == null) { // If theres no Slot in the SlotUI component...
                foreach (var slot in player.Inventory()) // Loop for every Slot in the inventory
                {
                    if (slot.position == currentPosition) {                    
                        slotUI.SetSlot(slot); 
                        slot.setSlotUI(slotUI); 

                        //UpdateInventoryUI(); ?

                        // Debug.Log("Assigned slot UI to slot at position: " + currentPosition);
                        return;
                    }
                }
            }
        }
    }

    public void UpdateInventoryUI (Player player) {
        for (int y = player.inventorySize.y; y > 0; y--)
        {
            for (int x = 0; x < player.inventorySize.x; x++) // Should inventory size be in gamemanager and not player? maybe
            {
                Slot slot = player.GetSlotAtPosition(new Vector2Int(x + 1, y));

                if (slot == null) { // I tried "is" and "is not"
                    //slot.slotUI.DisableIcon(); // Can't do this because slot is null, and so theres no reference to a slotUI
                    //slot.slotUI.ClearAmount();
                } else {
                    slot.slotUI.SetIcon(slot.item.getIcon());
                    slot.slotUI.SetAmount(slot.amount);
                }
            }
        }
    }
}