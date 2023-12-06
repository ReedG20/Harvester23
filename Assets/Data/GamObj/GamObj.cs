using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GamObj", menuName = "Data/GamObj")]
public class GamObj : ScriptableObject
{
    public new string name;
    public GamObj derivedGamObj; // What is this

    [Space]
    public GameObject model;
    public List<GameObject> states;
    // add ground or above ground

    [Space]
    public List<Drop> drops;
}

[System.Serializable]
public class Drop {
    public Item item;
    public int amount;

    // public float chance;
}