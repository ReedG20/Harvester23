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
    GameObject tempPlayer;

    List<Player> players = new List<Player>();

    public InventoryUI inventoryUI;

    void Awake() {
        // Uncomment once figured out how to instantiate camera with player and have player count and multiplayer work
        //GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.Euler(0f, 0f, 0f)); // Instantiate the player prefab

        players.Add(new Player("Player1", tempPlayer)); // Create a new player in the list and add a reference to the prefab we just created

        inventoryUI.SetupInventory(players[0]); // I don't really know where this should go. I don't know what the hierarchy of things should look like
    }

    public Player GetPlayer (int i) {
        if (players[i] != null) {
            return players[i];
        }
        return null;
    }
}