using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameObject : MonoBehaviour // Consider removing monobehaviour
{
    // Tile contains info about the gameObj of the ground and above ground
    public Tile tile; // Consider making these variables private with accessing functions
    public Layer layer; // Why does this matter?
}