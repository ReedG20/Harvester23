using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    float force = 500f;
    float forceUp = 200f;

    [SerializeField]
    int playerIndex;

    public void ShootProjectile(Movement movement) {
        GameObject projectileInMotion = Instantiate(projectile, movement.gameObject.transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
        projectileInMotion.name = "Projectile" + playerIndex.ToString();
        projectileInMotion.GetComponent<Rigidbody>().AddForce(new Vector3(movement.direction.x * force, forceUp, movement.direction.y * force));
    }
}
