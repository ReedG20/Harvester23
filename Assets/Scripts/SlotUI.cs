using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    Slot slot; // Keeps track of the item, amount, and position

    Image image;
    TextMeshPro text;

    void Awake() {
        image = GetComponentInChildren<Image>(); // Only works because there is only one image component in all of the children of InventorySlot
        text = GetComponentInChildren<TextMeshPro>(); // Same as above
    }

    public void SetSlot (Slot slot) {
        this.slot = slot; // "this" is used to specify which "slot" to use. Only really used at the start of the game
    }

    public Slot GetSlot () {
        return slot;
    }

    public void SetIcon (Sprite icon) {
        image.sprite = icon;
        image.enabled = true;
    }

    public void DisableIcon () {
        image.sprite = null;
        image.enabled = false;
    }

    public void SetAmount (int amount) {
        text.text = amount.ToString();
    }

    public void ClearAmount () {
        text.text = "0";
    }
}