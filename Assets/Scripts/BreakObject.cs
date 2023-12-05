using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    [SerializeField]
    float reach = 2f;

    public void BreakInGameObject() {
        Debug.Log("BreakInGameObject called");
        Ray ray = new Ray(transform.position, transform.forward * reach); // Raycast should generally be in FixedUpdate, but this should work

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            Destroy(hit.collider.gameObject);
        }
    }
}
