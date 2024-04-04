using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    GameObject dieScreen;

    [SerializeField]
    int playerIndex;
    Player player;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    Slider healthSlider;

    void Start()
    {
        player = gameManager.GetPlayer(playerIndex);

        dieScreen.SetActive(false);
        healthSlider.value = 1f;
    }

    void OnCollisionEnter(Collision collision) {
        if ((playerIndex == 0 && collision.gameObject.name == "Projectile1") || (playerIndex == 1 && collision.gameObject.name == "Projectile0")) {
            Debug.Log("Player " + playerIndex + "took damage");
            player.DamagePlayer(10);
            healthSlider.value = player.health / 100f;
        }
        if (player.health <= 0) {
            dieScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Player " + (playerIndex + 1) + " died";
            dieScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}