using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField]
    GameObject dieScreen;

    [SerializeField]
    int playerIndex;

    void Start()
    {
        dieScreen.SetActive(false);
    }

    void OnCollisionEnter(Collision collision) {
        if ((playerIndex == 0 && collision.gameObject.name == "Projectile1") || (playerIndex == 1 && collision.gameObject.name == "Projectile0")) {
            Debug.Log("Player " + playerIndex + " died");
            Destroy(gameObject);

            dieScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Player " + (playerIndex + 1) + " died";
            dieScreen.SetActive(true);
        }
    }
}
