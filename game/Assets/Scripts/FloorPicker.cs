using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPicker : MonoBehaviour
{
    [SerializeField] private Tileset tileset;

    private string floorCode;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = tileset.floors.Find(n =>  n.name == "floor"+floorCode );
    }

    public void ParseCode(int code)
    {
        floorCode = code.ToString();
        while (floorCode.Length < 4) floorCode = "0" + floorCode;
    }
}
