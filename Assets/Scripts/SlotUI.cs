using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    Slot slot; // Keeps track of the item, amount, and position

    Image image;
    TextMeshProUGUI text;

    void Awake() {
        image = GetComponentInChildren<Image>(); // Only works because there is only one image component in all of the children of InventorySlot
        text = GetComponentInChildren<TextMeshProUGUI>(); // Only works because there is only one TMP component in all of the children of InventorySlot
    }

    public void SetSlot (Slot slot) {
        this.slot = slot;
    }

    public Slot GetSlot () {
        return slot;
    }

    public void SetIcon (Sprite icon) {
        if (image == null) {
            Debug.LogError("Image is null");
            return;
        }
        image.sprite = icon;
        image.enabled = true;
    }

    public void DisableIcon () {
        if (image == null) {
            Debug.LogError("Image is null");
            return;
        }
        image.enabled = false;
        image.sprite = null;
    }

    public void SetAmount (int amount) {
        if (text == null) {
            Debug.LogError("Text is null");
            return;
        }
        text.text = amount.ToString();
    }

    public void ClearAmount () {
        if (text == null) {
            Debug.LogError("Text is null");
            return;
        }
        text.text = "0";
    }
}