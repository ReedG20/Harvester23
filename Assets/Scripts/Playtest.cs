using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playtest : MonoBehaviour
{
    private CustomInput input = null;

    [SerializeField]
    Item testItem1;
    [SerializeField]
    Item testItem2;

    [SerializeField]
    GameManager gameManager;

    void Awake() {
        input = new CustomInput();
    }

    void OnEnable() {
        input.Enable();
        input.Playtest.AddItem1.performed += ctx => AddItem(testItem1); // E on the keyboard
        input.Playtest.AddItem2.performed += ctx => AddItem(testItem2); // E on the keyboard
    }

    void OnDisable() {
        input.Disable();
        input.Playtest.AddItem1.performed -= ctx => AddItem(testItem1);
        input.Playtest.AddItem2.performed -= ctx => AddItem(testItem2);
    }

    void AddItem (Item item) {
        gameManager.GetPlayer(0).AddToInventory(item, 1, null);

        gameManager.GetPlayer(0).UpdateInventoryUI();
    }
}
