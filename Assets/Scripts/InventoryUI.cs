using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    SlotUI[] slotUI; // Array of all the SlotUI components

    // Connects all the SlotUI components with their respective slots
    public void SetupInventory (Player player) {
        slotUI = GetComponentsInChildren<SlotUI>(); // Get the array of all the SlotUI components in the slot gameobjects

        var inventory = player.Inventory(); // Get the inventory of the player

        for (int y = player.inventorySize.y; y > 0; y--) // Top to bottom
        {
            for (int x = 0; x < player.inventorySize.x; x++) // Left to right
            {
                Vector2Int currentPosition = new Vector2Int(x + 1, y + 1); // The coordinates we are currently on
                foreach (var slotUI in slotUI) // Loop for every SlotUI component in the array
                {
                    if (slotUI.GetSlot() == null) { // If theres no Slot in the SlotUI component...
                        foreach (var slot in player.Inventory()) // Loop for every Slot in the inventory
                        {
                            if (slot.position == currentPosition) { // If the position of that Slot in the inventory matches the position we are at...
                                slotUI.SetSlot(slot); // Set the Slot in the SlotUI to that Slot
                                slot.slotUI = slotUI; // And set the Slot's reference to the SlotUI to that SlotUI
                                // To summarize, this function goes through each tile in the grid of the inventory, and finds the next SlotUI component with no Slot attached to it. Assuming that the order of SlotUIs is correct, the Slot matching the position that we are currently at is matched up with that SlotUI component. The Slot has a reference to the SlotUI and the SlotUI has a reference to the Slot

                                //UpdateInventoryUI(); maybe?
                            }
                        }
                    }
                }
            }
        }

        //UpdateInventoryUI(player);
    }

    public void UpdateInventoryUI (Player player) {
        for (int y = player.inventorySize.y; y > 0; y--)
        {
            for (int x = 0; x < player.inventorySize.x; x++) // Should inventory size be in gamemanager and not player? maybe
            {
                Slot slot = player.GetSlotAtPosition(new Vector2Int(x, y));

                if (slot.item == null) { //I tried is and is not
                    slot.slotUI.DisableIcon();
                    slot.slotUI.ClearAmount();
                } else {
                    slot.slotUI.SetIcon(slot.item.getIcon());
                    slot.slotUI.SetAmount(slot.amount);
                }
            }
        }
    }
}