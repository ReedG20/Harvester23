using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    SlotUI[] slotUIs; // Array of all the SlotUI components

    // Connects all the SlotUI components with their respective slots
    public void SetupInventory (Player player) {

        slotUIs = GetComponentsInChildren<SlotUI>(); // This works, and we end up with 40 SlotUIs

        for (int y = player.inventorySize.y; y > 0; y--) // Top to bottom
        {
            for (int x = 1; x <= player.inventorySize.x; x++) // Left to right
            {
                // (1, 5), (2, 5)... (7, 1), (8, 1)

                SetupInventoryExtension(new Vector2Int(x, y), player); // This needs a better name, or I need to change how I do it
            }
        }

        UpdateInventoryUI(player);
    }
    void SetupInventoryExtension (Vector2Int currentPosition, Player player) { // Function because I need the break functionality to exit the nested loops
        foreach (var s in slotUIs) // Loop for every SlotUI component in the array 
        {
            if (s.GetSlot() == null) { // If theres no Slot in the SlotUI component...
                foreach (var slot in player.Inventory()) // Loop for every Slot in the inventory
                {
                    if (slot.position == currentPosition) {       
                        // Now we have found the corresponding Slot and SlotUI
                        // and we want to give them pointers to each other
                        Debug.Log("`Calling SetSlot with "+s+" and " + slot);
                        s.SetSlot(slot);
                        slot.SetSlotUI(s); // This still does not work for some reason

                        // This isssue was that I was calling UpdateInventoryUI here which is stupid

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
            for (int x = 1; x <= player.inventorySize.x; x++) // Should inventory size be in gamemanager and not player? maybe
            {
                Debug.Log("Going through loop of UpdateInventoryUI"); // Only called once, because somehow it is still getting stuck on SetAmount. slotUI is somehow null. 
                Slot slot = player.GetSlotAtPosition(new Vector2Int(x, y)); // This works
                SlotUI slotUI = slot.GetSlotUI();

                if (slot.amount == 0) {
                    slotUI.SetAmount(0); // There is still an issue here somehow?
                    slotUI.DisableIcon();
                } else if (slot.amount > 0) {
                    if (slot.item != null) {
                        slotUI.SetAmount(slot.amount);
                        slotUI.SetIcon(slot.item.getIcon());
                    } else {
                        Debug.LogError("Amount is greater than zero but item is null");
                    }
                } else { // Amount is less than zero
                    Debug.LogError("Amount is less than zero");
                }
            }
        }
    }
}