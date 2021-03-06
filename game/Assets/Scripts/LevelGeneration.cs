using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//class responsible for random level generation
public class LevelGeneration : MonoBehaviour
{
    //determines what type of object is set to appear on certain location
    private enum LevelTile { Empty, Floor, Wall, Player, Enemy};
    //theoretical grid of tiles
    private LevelTile[,] grid;
    //walker structure
    struct RandomWalker
    {
        public Vector2 Dir;
        public Vector2 Pos;
    }
    //list of walkers
    private List<RandomWalker> walkers;

    [SerializeField]
    private LevelProperties properties;
    
    //floor tile prefab
    private GameObject floorTile;
    //wall tile prefab
    private GameObject wallTile;
    //level width in tiles
    private int levelWidth;
    //level height in tiles
    private int levelHeight;
    //level percent to fill
    private float percentToFill = 0.2f;
    //chance for a walker to change direction
    private float chanceWalkerChangeDir = 0.5f;
    //chance for additional walker to spawn
    private float chanceWalkerSpawn = 0.05f;
    //chance for a walker to get destroyed
    private float chanceWalkerDestoy = 0.05f;
    //max number of walkers
    private int maxWalkers = 10;
    //iteration steps
    private int iterationSteps = 100000;
    //player prefab
    private GameObject player;
    //camera object to connect to player
    [SerializeField]
    private GameObject virtualCamera;
    //map object
    [SerializeField]
    private GameObject mapObject;

    [SerializeField] 
    private GameObject aliveEnemies;

    private List<GameObject> enemyTypes;

    private int amountOfEnemies;

    private Vector3 playerPos;

    private List<Vector3Int> floorSpaces;

    //[SerializeField] private GameObject tmp;

    //create the level
    void Start()
    {
        Init();
        Setup();
        CreateFloors();
        CreateWalls();
        SpawnLevel();
        SpawnBorder();
        SpawnPlayer();
        SpawnEnemies();
    }

    private void Init()
    {
        floorTile=properties.floorPrefab;
        wallTile=properties.wallPrefab;
        levelWidth=properties.levelWidth; 
        levelHeight=properties.levelHeight;
        percentToFill = properties.percentToFill;
        chanceWalkerChangeDir = properties.chanceWalkerChangeDir;
        chanceWalkerSpawn = properties.chanceWalkerSpawn;
        chanceWalkerDestoy = properties.chanceWalkerDestroy; 
        maxWalkers = properties.maxWalkers;
        iterationSteps = properties.iterationSteps;
        player = properties.playerObject;
        enemyTypes = properties.enemyTypes;
        amountOfEnemies = properties.amountOfEnemies;
    }

    //set up the walker alorithm
    private void Setup()
    {
        // prepare grid
        grid = new LevelTile[levelWidth, levelHeight];
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                grid[x, y] = LevelTile.Empty;
            }
        }

        //generate first walker
        walkers = new List<RandomWalker>();
        RandomWalker walker = new RandomWalker();
        walker.Dir = RandomDirection();
        Vector2 pos = new Vector2(Mathf.RoundToInt(levelWidth / 2.0f), Mathf.RoundToInt(levelHeight / 2.0f));
        walker.Pos = pos;
        walkers.Add(walker);
    }

    //choose a new random direction for a walker
    private Vector2 RandomDirection()
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
    //creates floor on the grid
    private void CreateFloors()
    {
        int iterations = 0;
        floorSpaces = new List<Vector3Int>();
        do
        {
            //create floor at position of every Walker
            foreach (RandomWalker walker in walkers)
            {
                grid[(int)walker.Pos.x, (int)walker.Pos.y] = LevelTile.Floor;
                floorSpaces.Add(new Vector3Int((int)walker.Pos.x, (int)walker.Pos.y, 0));
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
                    thisWalker.Dir = RandomDirection();
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
                    walker.Dir = RandomDirection();
                    walker.Pos = walkers[i].Pos;
                    walkers.Add(walker);
                }
            }

            //move Walkers
            for (int i = 0; i < walkers.Count; i++)
            {
                RandomWalker walker = walkers[i];
                walker.Pos += walker.Dir;
                walkers[i] = walker;
            }

            //avoid boarder of grid
            for (int i = 0; i < walkers.Count; i++)
            {
                RandomWalker walker = walkers[i];
                walker.Pos.x = Mathf.Clamp(walker.Pos.x, 1, levelWidth - 2);
                walker.Pos.y = Mathf.Clamp(walker.Pos.y, 1, levelHeight - 2);
                walkers[i] = walker;
            }

            //check to exit loop
            if (NumberOfFloors() / (float)grid.Length > percentToFill)
            {
                break;
            }
            iterations++;
        } while (iterations < iterationSteps);
    }

    //returns the number of floor tiles on the stage
    private int NumberOfFloors()
    {
        int count = 0;
        foreach (LevelTile space in grid)
        {
            if (space == LevelTile.Floor)
            {
                count++;
            }
        }
        return count;
    }

    //create walls around floors 
    private void CreateWalls()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                if (grid[x, y] == LevelTile.Empty) grid[x, y] = LevelTile.Wall;
            }
        }
    }

    //spawn floor and wall prefabs in place of floor and wall tiles
    private void SpawnLevel()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                switch (grid[x, y])
                {
                    case LevelTile.Empty:
                        break;
                    case LevelTile.Floor:
                        int code = 0;
                        if (grid[x, y + 1] == LevelTile.Wall) code += 1000;
                        if (grid[x, y - 1] == LevelTile.Wall) code += 100;
                        if (grid[x + 1, y] == LevelTile.Wall) code += 1;
                        if (grid[x - 1, y] == LevelTile.Wall) code += 10;
                        Spawn(x, y, floorTile, code);
                        break;
                    case LevelTile.Wall:
                        Spawn(x, y, wallTile);
                        break;
                }
            }
        }
    }

    //spawn a border around level to prevent falling out of the map
    private void SpawnBorder()
    {
        //create a square of walls around map
        for (int i = -1; i < levelWidth+1; i++)
        {
            Spawn(i, -1, wallTile);
            Spawn(i, levelHeight, wallTile);
        }
        for (int i = -1; i < levelHeight+1; i++)
        {
            Spawn(-1, i, wallTile);
            Spawn(levelWidth, i, wallTile);
        }

        //set a camera collider on the border
        PolygonCollider2D cameraBorder = mapObject.GetComponent<PolygonCollider2D>();
        Vector2[] points = new Vector2[4];
        points[0] = new Vector2(-1, -1);
        points[1] = new Vector2(levelWidth, -1);
        points[2] = new Vector2(levelWidth, levelHeight);
        points[3] = new Vector2(-1, levelHeight);
        cameraBorder.SetPath(0,points);
        CinemachineConfiner confiner = virtualCamera.GetComponent<CinemachineConfiner>();
        confiner.m_BoundingShape2D = cameraBorder;
    }

    //spawn player in the center of stage
    private void SpawnPlayer()
    {
        playerPos = new Vector3(Mathf.RoundToInt(levelWidth / 2.0f),
                                        Mathf.RoundToInt(levelHeight / 2.0f));
        GameObject playerObj = Instantiate(player, Vector3.zero, Quaternion.identity);
        //GameObject testEnemy = Instantiate(tmp, pos, Quaternion.identity);
        playerObj.transform.GetChild(1).localPosition = playerPos;
        grid[levelWidth / 2, levelHeight / 2] = LevelTile.Player;
        CinemachineVirtualCamera vCam = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        vCam.m_Follow = playerObj.transform.GetChild(0);
    }

    private void SpawnEnemies()
    {
        floorSpaces = floorSpaces.Distinct().ToList();
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Vector3Int pos;
            do
            {
                pos = floorSpaces[Random.Range(0, floorSpaces.Count)];
            } while (grid[pos.x, pos.y] != LevelTile.Floor || Vector3.Distance(pos, playerPos) <= 5);

            GameObject enemyObj = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Count)], pos, Quaternion.identity);
            grid[pos.x, pos.y] = LevelTile.Enemy;
        }
    }

    //spawn an object in certain location
    private void Spawn(float x, float y, GameObject toSpawn, int code=1111)
    {
        GameObject newObject = Instantiate(toSpawn, new Vector3(x, y, 0), Quaternion.identity);
        newObject.transform.parent = mapObject.transform;
        if (code != 1111)
        {
            newObject.transform.GetChild(0).GetComponent<FloorPicker>().ParseCode(code);
        }
    }
}
