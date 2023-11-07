using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    string name;

    GameObject playerObject;

    List<Slot> inventory;

    // Should inventorySize not be here?
    public readonly Vector2Int inventorySize = new Vector2Int(8, 5); // Inventory position bounds (8 x 6 and the 8-slot hotbar)

    // Player constructor
    public Player(string name, GameObject playerObject) {
        this.name = name;
        this.playerObject = playerObject;
        
        inventory = new List<Slot>();
        CreateInventory();
    }


    // Player Object //

    // Set the player object
    public void SetPlayerObject(GameObject playerObject) {
        this.playerObject = playerObject;
    }

    // Get the player object
    public GameObject PlayerObject() {
        return this.playerObject;
    }


    // Inventory //

    // Setup new empty inventory
    [SerializeField]
    public void CreateInventory() {
        for (int y = inventorySize.y; y > 0; y--) { // Changed from y++ to y-- because I feel like thats what it should be?
            for (int x = 1; x <= inventorySize.x; x++) {
                inventory.Add(new Slot(null, 0, new Vector2Int(x + 1, y)));
            }
        }
    }

    // Add item to inventory
    public void AddToInventory(Item item, int amount, bool includesPosition, Vector2Int position) { // This function needs to be changed. We cannot add new inventory slots at all
        if (amount > 0) { // If the amount is greater than zero...
            if (inventory.Exists(x => x.item == item)) { // If the item already exists in the inventory...
                inventory.Find(x => x.item == item).amount += amount; // ...add it to that inventory slot
            } else {
                inventory.Add(new Slot(item, amount, new Vector2Int(1, 1))); // This needs to be changed. 
            }
        } else {
            Debug.LogError("invalid amount of items to add!");
        }
    }

    // Remove item from inventory at a position
    public void RemoveItemFromInventory(Item item, int amount) { // Need to figure out if it is necessary to know if the amount is too much here or before here. Probably before here
        if (GetItemAmount(item) >= amount && amount > 0) {
            List<Slot> result = inventory.FindAll(slot => slot.item == item);

            int itemsLeftToRemove = amount;

            for (int y = inventorySize.y; y > 0; y--) { // y (should work backwards)
                for (int x = 0; x < inventorySize.x; x++) { // x

                    foreach (Slot slot in result) {
                        if (slot.position.x == x + 1 && slot.position.y == y) { // + 1 because for statements begin at 0, but our grid's coordinates start at 1

                            if (slot.amount >= itemsLeftToRemove) { // If there are enough items in the slot

                                slot.amount -= itemsLeftToRemove; // Remove items from the slot
                                itemsLeftToRemove -= itemsLeftToRemove; // No more items to remove

                            } else if (slot.amount < itemsLeftToRemove) { // If there are not enough items in the slot to be removed

                                itemsLeftToRemove -= slot.amount; // Reduce itemsLeftToRemove
                                slot.amount -= slot.amount; // Remove all the items in that slot

                            }
                            UpdateInventory();
                        }

                        if (itemsLeftToRemove == 0) { // If there are no more items to be removed from the inventory...
                            break; // Foreach loop is ended
                        }
                    }
                }
            }

        } else {
            Debug.LogError("invalid amount of items to remove!");
        }
    }

    // Remove the item at a position in the inventory
    public void RemovePositionFromInventory(Vector2Int position, int amount) { // If the amount is like half or something, get the amount of items in the slot, do the calculation elswhere, and then put that as the amount. Also, to use this function, you need to know the amount already in the slot
        foreach (Slot slot in inventory) {
            if (slot.position == position) {
                slot.amount -= amount;
            }
        }
    }


    // Get the inventory list
    public List<Slot> Inventory() { // Maybe add AsReadOnly? Or honestly maybe this function shouldn't exist, I should just have getter and setter functions, and maybe inventory should be a class, and then player could have an inventory. That would make more sense
        return this.inventory;
    }

    // Get the total amount of a certain item in the inventory
    public int GetItemAmount(Item item) {
        List<Slot> result = inventory.FindAll(slot => slot.item == item); // Equals operation should work fine

        int sum = 0;
        foreach (var slot in result) { // Add up all the amounts
            sum += slot.amount;
        }

        return sum;
    }

    public Slot GetSlotAtPosition(Vector2Int position) {
        foreach (var slot in inventory)
        {
            if (slot.position == position) {
                return slot;
            }
        }
        return null; // Necessary so that all paths return a value
    }

    void UpdateInventory() {
        foreach (Slot slot in inventory) {
            if (slot.amount == 0) {
                slot.item = null;
            } else if (slot.amount < 0) {
                Debug.LogError("can't have a negative amount! Negative amount of " + slot.item.Name() + " at " + slot.position);
                slot.item = null;
                slot.amount = 0;
            } // Otherwise nothing else needs to happen
        }
    }
}


public class Slot {
    public Item item;
    public int amount;
    public Vector2Int position;

    public SlotUI slotUI;

    public Slot(Item item, int amount, Vector2Int position) {
        this.item = item;
        this.amount = amount;
        this.position = position;
    }
}