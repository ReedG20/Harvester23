using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private CustomInput input = null;

    private Vector2 moveVector = Vector2.zero;
    private Vector3 force = Vector3.zero;

    private Rigidbody rb;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float acceleration = 1f;

    private void Awake() {
        input = new CustomInput();
    }

    private void OnEnable() {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable() {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (Mathf.Abs(rb.velocity.magnitude) < speed) {
            force = new Vector3(moveVector.x * acceleration, 0f, moveVector.y * acceleration);
        }
        
        rb.AddForce(force);

        force = Vector3.zero;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value) {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value) {
        moveVector = Vector2.zero;
    }
}