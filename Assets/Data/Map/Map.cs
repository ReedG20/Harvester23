using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Map
[CreateAssetMenu(fileName = "New Map", menuName = "Data/Map")]
public class Map : ScriptableObject
{
    public int size;
    
    public bool useCustomSeed = false;
    public float customSeed;
  
    public float biomeNoiseScale = 0.1f;
    public List<Biome> biomes;
}

// Biome
[System.Serializable]
public class Biome {
    public string name = "biome";

    public int noiseSeed;

    [Range(-1f, 1f)]
    public float sizePriority = 0f;

    [Header("order: top to bottom, elements may take the place of elements above them in the list")]
    public List<BiomeElement> biomeElements;
}

// Biome Element
[System.Serializable]
public class BiomeElement {
    public GamObj gamObj;
    public Layer layer;
    [Space]
    [Space]

    public float noiseScale = 1f;
    [Space]

    [Header("Seed (Using the same seed as another element layers the two)")]
    public int noiseSeed = 0; // Using the same noiseSeed as another element puts them in the same place
    public int randomSeed = 0; // Using the same randomSeed layers the two elements on top of eachother
    [Space]

    [Header("Cutoff (0 is nothing and 1 is full)")]
    [Range(0f, 1f)]
    public float noiseCutoff = 0.5f; // 0 is nothing and 1 is full
    [Range(0f, 1f)]
    public float randomCutoff = 0.5f; // 0 is nothing and 1 is full
}

public enum Layer {
    aboveGround,
    ground,
}