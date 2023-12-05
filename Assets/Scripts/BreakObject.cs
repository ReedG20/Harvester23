using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    [SerializeField]
    float reach = 5f;

    [SerializeField]
    Movement movement;

    public void BreakInGameObject() {
        Debug.Log("BreakInGameObject called");
        Debug.Log(movement.direction);
        Ray ray = new Ray(transform.position, new Vector3(movement.direction.x, 0f, movement.direction.y)); // Raycast should generally be in FixedUpdate, but this should work

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reach)) {
            Debug.Log("Hit something");
            Destroy(hit.collider.gameObject);
        }
    }
}
