using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class responsible for random level generation
public class LevelGeneration : MonoBehaviour
{
    //determines what type of object is set to appear on certain location
    enum LevelTile { empty, floor, wall};
    //theoretical grid of tiles
    LevelTile[,] grid;
    //walker structure
    struct RandomWalker
    {
        public Vector2 dir;
        public Vector2 pos;
    }
    //list of walkers
    List<RandomWalker> walkers;

    //floor tile prefab
    [SerializeField]
    public GameObject floorTile;
    //wall tile prefab
    [SerializeField]
    public GameObject wallTile;
    //level width in tiles
    public int levelWidth;
    //level height in tiles
    public int levelHeight;
    //level percent to fill
    public float percentToFill = 0.2f;
    //chance for a walker to change direction
    public float chanceWalkerChangeDir = 0.5f;
    //chance for additional walker to spawn
    public float chanceWalkerSpawn = 0.05f;
    //chance for a walker to get destroyed
    public float chanceWalkerDestoy = 0.05f;
    //max number of walkers
    public int maxWalkers = 10;
    //iteration steps
    public int iterationSteps = 100000;

    //create the level
    void Start()
    {
        Setup();
        CreateFloors();
        CreateWalls();
        SpawnLevel();
    }

    //set up the walker alorithm
    void Setup()
    {
        // prepare grid
        grid = new LevelTile[levelWidth, levelHeight];
        for (int x = 0; x < levelWidth - 1; x++)
        {
            for (int y = 0; y < levelHeight - 1; y++)
            {
                grid[x, y] = LevelTile.empty;
            }
        }

        //generate first walker
        walkers = new List<RandomWalker>();
        RandomWalker walker = new RandomWalker();
        walker.dir = RandomDirection();
        Vector2 pos = new Vector2(Mathf.RoundToInt(levelWidth / 2.0f), Mathf.RoundToInt(levelHeight / 2.0f));
        walker.pos = pos;
        walkers.Add(walker);
    }

    //choose a new random direction for a walker
    Vector2 RandomDirection()
    {
        int choice = Mathf.FloorToInt(Random.value * 3.99f);
        switch (choice)
        {
            case 0:
                return Vector2.down;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.up;
            default:
                return Vector2.right;
        }
    }

    void CreateFloors()
    {
        int iterations = 0;
        do
        {
            //create floor at position of every Walker
            foreach (RandomWalker walker in walkers)
            {
                grid[(int)walker.pos.x, (int)walker.pos.y] = LevelTile.floor;
            }

            //chance: destroy Walker
            int numberChecks = walkers.Count;
            for (int i = 0; i < numberChecks; i++)
            {
                if (Random.value < chanceWalkerDestoy && walkers.Count > 1)
                {
                    walkers.RemoveAt(i);
                    break;
                }
            }

            //chance: Walker pick new direction
            for (int i = 0; i < walkers.Count; i++)
            {
                if (Random.value < chanceWalkerChangeDir)
                {
                    RandomWalker thisWalker = walkers[i];
                    thisWalker.dir = RandomDirection();
                    walkers[i] = thisWalker;
                }
            }

            //chance: spawn new Walker
            numberChecks = walkers.Count;
            for (int i = 0; i < numberChecks; i++)
            {
                if (Random.value < chanceWalkerSpawn && walkers.Count < maxWalkers)
                {
                    RandomWalker walker = new RandomWalker();
                    walker.dir = RandomDirection();
                    walker.pos = walkers[i].pos;
                    walkers.Add(walker);
                }
            }

            //move Walkers
            for (int i = 0; i < walkers.Count; i++)
            {
                RandomWalker walker = walkers[i];
                walker.pos += walker.dir;
                walkers[i] = walker;
            }

            //avoid boarder of grid
            for (int i = 0; i < walkers.Count; i++)
            {
                RandomWalker walker = walkers[i];
                walker.pos.x = Mathf.Clamp(walker.pos.x, 1, levelWidth - 2);
                walker.pos.y = Mathf.Clamp(walker.pos.y, 1, levelHeight - 2);
                walkers[i] = walker;
            }

            //check to exit loop
            if ((float)NumberOfFloors() / (float)grid.Length > percentToFill)
            {
                break;
            }
            iterations++;
        } while (iterations < iterationSteps);
    }

    //returns the number of floor tiles on the stage
    int NumberOfFloors()
    {
        int count = 0;
        foreach (LevelTile space in grid)
        {
            if (space == LevelTile.floor)
            {
                count++;
            }
        }
        return count;
    }

    //create walls around floors 
    void CreateWalls()
    {
        for (int x = 0; x < levelWidth - 1; x++)
        {
            for (int y = 0; y < levelHeight - 1; y++)
            {
                if (grid[x, y] == LevelTile.empty) grid[x, y] = LevelTile.wall;
            }
        }
    }

    //spawn floor and wall prefabs in place of floor and wall tiles
    void SpawnLevel()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                switch (grid[x, y])
                {
                    case LevelTile.empty:
                        break;
                    case LevelTile.floor:
                        Spawn(x, y, floorTile);
                        break;
                    case LevelTile.wall:
                        Spawn(x, y, wallTile);
                        break;
                }
            }
        }
    }

    //spawn an object in certain location
    void Spawn(float x, float y, GameObject toSpawn)
    {
        Instantiate(toSpawn, new Vector3(x, y, 0), Quaternion.identity);
    }
}
