using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    float force = 500f;
    float forceUp = 200f;

    [SerializeField]
    int playerIndex;

    [SerializeField]
    GameManager gameManager;

    public void ShootProjectile(Movement movement) {
        Item item = gameManager.GetPlayer(playerIndex).RemoveItemFromPosition(new Vector2Int(0, 0), 1);

        if (item != null) {
            GameObject projectileInMotion = Instantiate(projectile, movement.gameObject.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
            projectileInMotion.name = "Projectile" + playerIndex.ToString();
            projectileInMotion.GetComponent<Rigidbody>().AddForce(new Vector3(movement.direction.x * force, forceUp, movement.direction.y * force));
        } else {
            Debug.Log("No item to shoot");
        }
    }
}
