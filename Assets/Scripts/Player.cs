using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player {
    string name;

    GameObject playerObject;

    public Slot[,] inventory;

    // Should inventorySize not be here? YES
    public readonly Vector2Int inventorySize = new Vector2Int(5, 4); // Inventory position bounds (8 x 4 and the 8-slot hotbar)

    // Player constructor
    public Player(string name, GameObject playerObject) {
        this.name = name;
        this.playerObject = playerObject;

        CreateInventory();
    }

    // Inventory //

    // Setup a new empty inventory
    public void CreateInventory() {
        inventory = new Slot[inventorySize.x, inventorySize.y];

        for (int y = 0; y < inventorySize.y; y++)
        {
            for (int x = 0; x < inventorySize.x; x++)
            {
                inventory[x, y] = new Slot(null, 0);
            }
        }
    }

    // Add item to inventory
    public void AddToInventory(Item item, int amount, Vector2Int? position) {
        if (amount == 0 || item == null) {
            Debug.LogError("Invalid item or amount!");
            return;
        }

        if (position == null) {
            Vector2Int? tempPosition = FindAvailablePosition(item);

            if (tempPosition == null) { 
                Debug.Log("No available position");
                return;
            }
            position = (Vector2Int)tempPosition;
        }

        // We now have a position

        Slot slot = inventory[((Vector2Int)position).x, ((Vector2Int)position).y];

        if (slot.item == null) {
            slot.item = item;
            slot.amount = amount;
        } else if (slot.item == item) {
            slot.amount += amount;
        } else {
            Debug.Log("Item at position is not the same as the item we are trying to add!");
            // Move it over to the next available position
            return;
        }

        UpdateInventoryUI();
    }

    // Find an available position in the inventory for an item
    private Vector2Int? FindAvailablePosition(Item item)
    {
        Vector2Int? firstEmptySlot = null;
        for (int y = 0; y < inventorySize.y; y++)
        {
            for (int x = 0; x < inventorySize.x; x++)
            {
                if (inventory[x, y].item == item) {
                    return new Vector2Int(x, y);
                }
                if (inventory[x, y].item == null && firstEmptySlot == null) {
                    firstEmptySlot = new Vector2Int(x, y);
                }
            }
        }
        return firstEmptySlot;
    }

    // Remove item from inventory
    public void RemoveItemFromInventory(Item item, int amount) { 
        for (int y = 0; y < inventorySize.y; y++)
        {
            for (int x = 0; x < inventorySize.x; x++)
            {
                if (item = inventory[x, y].item) {
                    if (amount <= inventory[x, y].amount) {
                        inventory[x, y].amount -= amount;
                        return;
                    } else {
                        amount -= inventory[x, y].amount;
                        inventory[x, y].amount = 0;
                    }
                }
            }
        }

        UpdateInventoryUI();
    }

    // Remove the item from the inventory at a position
    public void RemoveItemFromPosition(Vector2Int position, int amount) {
        if (amount == 0) {
            Debug.LogError("Invalid amount!");
            return;
        }

        Slot slot = inventory[position.x, position.y];

        if (slot.item == null) {
            Debug.LogError("No item at position!");
            return;
        }

        if (amount > slot.amount) {
            Debug.LogError("Amount is greater than amount in slot!");
            return;
        }

        slot.amount -= amount;

        UpdateInventoryUI();
    }

    // Get the total amount of a certain item in the inventory
    public int GetItemAmount(Item item) {
        int totalAmount = 0;

        foreach (Slot slot in inventory) {
            if (slot.item == item) {
                totalAmount += slot.amount;
            }
        }

        return totalAmount;
    }

    public void UpdateInventoryUI() {
        foreach(Slot slot in inventory) {
            SlotUI slotUI = slot.slotUI;

            if (slot.amount == 0) {
                slotUI.SetAmount(0); 
                slotUI.DisableIcon();
            } else if (slot.amount > 0) {
                slotUI.SetAmount(slot.amount);
                slotUI.SetIcon(slot.item.getIcon());
            } else { // Amount is less than zero
                Debug.LogError("Amount is less than zero");
            }
        }
    }
}

public class Slot {
    public Item item;
    public int amount;

    public SlotUI slotUI;

    public Slot(Item item, int amount) {
        this.item = item;
        this.amount = amount;
    }
}