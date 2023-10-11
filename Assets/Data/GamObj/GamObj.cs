using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GamObj", menuName = "Data/GamObj")]
public class GamObj : ScriptableObject
{
    [SerializeField]
    new string name;
    [SerializeField]
    GamObj derivedGamObj;

    [Space]
    public GameObject model;
    public List<GameObject> states;
    // add ground or above ground
}
