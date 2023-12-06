using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    [SerializeField]
    float reach = 5f;


    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    Movement movement;

    public void BreakInGameObject() {
        Debug.Log("BreakInGameObject called");
        Ray ray = new Ray(transform.position, new Vector3(movement.direction.x, 0f, movement.direction.y)); // Raycast should generally be in FixedUpdate, but this should work

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reach)) {
            GamObj gamObj = hit.collider.gameObject.GetComponent<InGameObject>().tile.aboveGround;

            if (gamObj.drops.Count > 0) {
                foreach (Drop drop in gamObj.drops) {
                    Debug.Log("Adding drop to inventory: " + drop.amount + " " + drop.item.name);
                    gameManager.GetPlayer(0).AddToInventory(drop.item, drop.amount, null);
                }
            }

            Debug.Log("Destroying object");
            Destroy(hit.collider.gameObject);

            // Update World data
        }
    }
}
