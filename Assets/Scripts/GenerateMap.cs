using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField]
    bool generateMap;
    [SerializeField]
    Map map; // Map stores the instructions on how to create a world
    [SerializeField]
    bool GenerateAtCenter = true; // Not currently in use
    World world; // World stores the data created by the map

    float bigNum = 12345.12345f; // decimal because of perlin noise bug

    // Collider sizes (maybe should move to GameManager or somewhere else)
    Vector3 aboveGroundColliderCenter = new Vector3(0f, 0f, 1f); // Weird because of blender rotation
    Vector3 aboveGroundColliderSize = new Vector3(2f, 2f, 2f);

    [SerializeField]
    PhysicMaterial slipperyPhysicMaterial;

    Quaternion objectRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f)); // Will remove soon. Wait how

    void Start() {

        if (generateMap) {
            world = new World();

            // Setting seed of world
            if (map.useCustomSeed)
                world.seed = map.customSeed;
            else
                world.seed = Random.Range(-1f, 1f);

            for (int x = 0; x < map.size; x++)
            {
                for (int y = 0; y < map.size; y++)
                {
                    Biome activeBiome = FindBiome(new Vector2(x, y));

                    Tile activeTile = FindTileInBiome(new Vector2(x, y), activeBiome);

                    world.AddTile(new Vector2(x, y), activeTile);
                }
            }

            Random.InitState((int)System.DateTime.Now.Ticks); // REMOVE LATER

            CreateWorld(world, map.size); // Physically create the world (instantiate the tiles)
        }
    }

    Biome FindBiome(Vector2 position) {
        float highestValue = 0f;
        int highestIndex = 0;
        for (int i = 0; i < map.biomes.Count; i++) {
            float value = Noise(position, map.biomeNoiseScale, map.biomes[i].noiseSeed) + map.biomes[i].sizePriority;
            if (value > highestValue) {
                highestIndex = i;
                highestValue = value;
            }
        }
        return map.biomes[highestIndex];
    }

    Tile FindTileInBiome(Vector2 position, Biome activeBiome) { // I changed this to System.Numerics.Vector2 from just Vector2
        Tile tile = new Tile(null, null);
        for (int i = 0; i < activeBiome.biomeElements.Count; i++) // Each biome element
        {
            BiomeElement activeBiomeElement = activeBiome.biomeElements[i];

            if (activeBiome.biomeElements[i].noiseCutoff > Noise(position, activeBiomeElement.noiseScale, activeBiomeElement.noiseSeed) && activeBiome.biomeElements[i].randomCutoff > RandomNum(position, activeBiomeElement.randomSeed)) { // wtf
                if (activeBiomeElement.layer == Layer.aboveGround) {
                    tile = new Tile(activeBiomeElement.gamObj, tile.ground);
                } else if (activeBiomeElement.layer == Layer.ground) {
                    tile = new Tile(tile.aboveGround, activeBiomeElement.gamObj);
                } else {
                    Debug.LogError("No layer found on " + activeBiomeElement.ToString());
                }
            }
        }
        return tile;
    }

    float Noise(Vector2 coordinates, float noiseScale, int noiseSeed) {
        return Mathf.PerlinNoise((coordinates.x * noiseScale) + (noiseSeed * bigNum * world.seed), (coordinates.y * noiseScale) + (noiseSeed * bigNum * world.seed)); // Seed stuff
    }

    float RandomNum(Vector2 coordinates, int randomSeed) {
        //return Mathf.PerlinNoise((coordinates.x * bigNum) + (randomSeed * bigNum * world.seed), (coordinates.y * bigNum) + (randomSeed * bigNum * world.seed)); // Using noise because of consistancy and seed
        return Random.Range(0f, 1f); // INCORPORATE SEED AND COORDINATES
    }

    void CreateWorld(World world, int size) {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                GameObject ground = null;
                GameObject aboveGround = null;

                Tile tile = world.GetTile(new Vector2(x, y));

                if (tile.ground) { // I think I could organize this so that instantiating and assigning everything is in its own function, because the majority of this code is repeated
                    ground = Instantiate(world.GetTile(new Vector2(x, y)).ground.model, new Vector3(x * 2, 0f, y * 2), objectRotation);

                    tile.groundObj = ground; // reference to gameobject for tile
                    // InGameObject component
                    InGameObject groundInGameObject = ground.AddComponent<InGameObject>(); // new InGameObject component on the gameobject
                    groundInGameObject.tile = tile; // reference to tile for gameobject (on component)
                    groundInGameObject.layer = Layer.ground; // record of layer for gameobject (on component)
                    // No collider
                }

                if (tile.aboveGround) {
                    aboveGround = Instantiate(world.GetTile(new Vector2(x, y)).aboveGround.model, new Vector3(x * 2, 0f, y * 2), objectRotation);

                    tile.aboveGroundObj = aboveGround;
                    // InGameObject component
                    InGameObject aboveGroundInGameObject = aboveGround.AddComponent<InGameObject>();
                    aboveGroundInGameObject.tile = tile;
                    aboveGroundInGameObject.layer = Layer.aboveGround;
                    // Collider
                    BoxCollider aboveGroundCollider = aboveGround.AddComponent<BoxCollider>();
                    aboveGroundCollider.center = aboveGroundColliderCenter;
                    aboveGroundCollider.size = aboveGroundColliderSize;
                    // Physic material
                    aboveGroundCollider.material = slipperyPhysicMaterial;
                }
            }
        }
    }
}

// Separate Classes //

public class World {
    public float seed;
    Dictionary<Vector2, Tile> world;

    public World() {
        this.world = new Dictionary<Vector2, Tile>();
    }

    public void AddTile(Vector2 position, Tile tile) {
        world.Add(position, tile);
    }

    public Tile GetTile(Vector2 position) {
        return world[position];
    }
}

public class Tile {
    public GamObj aboveGround;
    public GamObj ground;

    public GameObject aboveGroundObj;
    public GameObject groundObj;

    public Tile(GamObj aboveGround, GamObj ground) {
        this.aboveGround = aboveGround;
        this.ground = ground;
    }
}