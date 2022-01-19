using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles wall sprite randomisation 
public class WallRandomizer : MonoBehaviour
{
    [SerializeField] private Tileset tileset;
    
    //randomly selects the wall tile
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = tileset.walls[Random.Range(0, tileset.walls.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
