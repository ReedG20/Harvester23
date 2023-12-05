using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private CustomInput input = null;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    BreakObject breakObject;

    void Awake() {
        input = new CustomInput();
    }

    void OnEnable() {
        input.Enable();
        input.Player.Break.performed += ctx => breakObject.BreakInGameObject(); // E on the keyboard
    }

    void OnDisable() {
        input.Disable();
        input.Player.Break.performed -= ctx => breakObject.BreakInGameObject();
    }
}
