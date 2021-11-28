using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRandomizer : MonoBehaviour
{
    [SerializeField] private Tileset tileset;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = tileset.walls[Random.Range(0, tileset.walls.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
