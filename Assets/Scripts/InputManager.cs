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
    Movement movement1;
    [SerializeField]
    Movement movement2;
    
    [SerializeField]
    BreakObject breakObject1;
    [SerializeField]
    BreakObject breakObject2;

    [SerializeField]
    Shoot shoot1;
    [SerializeField]
    Shoot shoot2;

    void Awake() {
        input = new CustomInput();
    }

    void OnEnable() {
        input.Enable();

        input.Player1.Movement.performed += movement1.OnMovementPerformed;
        input.Player1.Movement.canceled += movement1.OnMovementCancelled;

        input.Player2.Movement.performed += movement2.OnMovementPerformed;
        input.Player2.Movement.canceled += movement2.OnMovementCancelled;

        input.Player1.Break.performed += ctx => breakObject1.BreakInGameObject(0, movement1);
        input.Player2.Break.performed += ctx => breakObject2.BreakInGameObject(1, movement2);

        input.Player1.Shoot.performed += ctx => shoot1.ShootProjectile(movement1);
        input.Player2.Shoot.performed += ctx => shoot2.ShootProjectile(movement2);
    }

    void OnDisable() {
        input.Disable();

        input.Player1.Movement.performed -= movement1.OnMovementPerformed;
        input.Player1.Movement.canceled -= movement1.OnMovementCancelled;

        input.Player2.Movement.performed -= movement2.OnMovementPerformed;
        input.Player2.Movement.canceled -= movement2.OnMovementCancelled;

        input.Player1.Break.performed -= ctx => breakObject1.BreakInGameObject(0, movement1);
        input.Player2.Break.performed -= ctx => breakObject2.BreakInGameObject(1, movement2);

        input.Player1.Shoot.performed -= ctx => shoot1.ShootProjectile(movement1);
        input.Player2.Shoot.performed -= ctx => shoot2.ShootProjectile(movement2);
    }
}
