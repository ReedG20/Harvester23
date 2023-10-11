using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Data/Item")]
public class Item : ScriptableObject
{
    // Item variables
    // Two options for name
    [SerializeField]
    new string name;
    [SerializeField]
    ItemType itemType;

    [SerializeField]
    GameObject model;
    [SerializeField]
    Sprite icon; // Temporary. Icon will later be replaced with the rendered model


    // Name of item
    public string Name() {
        if (itemType == ItemType.empty && name != null)
            return name;
        else
            return itemType.ToString();
    }

    public Sprite getIcon() {
        return icon;
    }
}

// Items with specific behavior
public enum ItemType {
    empty,
    item1,
    item2,
}