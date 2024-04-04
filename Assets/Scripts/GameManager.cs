using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField]
    //int playerAmount = 1;

    //[SerializeField]
    // GameObject playerPrefab;

    [SerializeField]
    GameObject Player1;
    [SerializeField]
    GameObject Player2;

    List<Player> players = new List<Player>();

    public InventoryUI inventoryUI1;
    public InventoryUI inventoryUI2;

    void Awake() {
        // Uncomment once figured out how to instantiate camera with player and have player count and multiplayer work
        //GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.Euler(0f, 0f, 0f)); // Instantiate the player prefab
        Debug.Log("Awake");
        players.Add(new Player("Player1", Player1)); // Create a new player in the list and add a reference to the prefab we just created
        Debug.Log("created player 1" + players[0].name);
        players.Add(new Player("Player2", Player2));
        Debug.Log("created player 2" + players[1].name);

        inventoryUI1.ConnectSlotUIsToInventory(players[0]);
        Debug.Log("Connected player 1 to inventoryUI1");
        inventoryUI2.ConnectSlotUIsToInventory(players[1]);
        Debug.Log("Connected player 2 to inventoryUI2");
    }

    public Player GetPlayer (int i) {
        if (players[i] != null) {
            return players[i];
        }
        return null;
    }
}