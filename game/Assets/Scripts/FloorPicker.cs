using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles setting correct sprites to floor tiles
public class FloorPicker : MonoBehaviour
{
    [SerializeField] private Tileset tileset;

    private string floorCode;
    // find the correct sprite using the generated code
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = tileset.floors.Find(n =>  n.name == "floor"+floorCode );
    }

    //parse the generated code to match the sprite file names
    public void ParseCode(int code)
    {
        floorCode = code.ToString();
        while (floorCode.Length < 4) floorCode = "0" + floorCode;
    }
}
