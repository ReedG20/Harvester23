using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playtest : MonoBehaviour
{
    private CustomInput input = null;

    [SerializeField]
    Item testItem;

    [SerializeField]
    GameManager gameManager;

    void Awake() {
        input = new CustomInput();
    }

    void Update() {
        int amount = gameManager.GetPlayer(0).GetItemAmount(testItem);
        Debug.Log(amount);
    }

    void OnEnable() {
        input.Enable();
        input.Playtest.AddItem.performed += ctx => AddItem(); // E on the keyboard
    }

    void OnDisable() {
        input.Disable();
        input.Playtest.AddItem.performed -= ctx => AddItem(); // I don't know if this will work
    }

    void AddItem () {
        gameManager.GetPlayer(0).AddToInventory(testItem, 1, false, Vector2Int.zero);

        gameManager.inventoryUI.UpdateInventoryUI(gameManager.GetPlayer(0));
    }
}
