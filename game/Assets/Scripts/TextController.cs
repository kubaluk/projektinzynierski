using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//handles displaying current amount of enemies
public class TextController : MonoBehaviour
{
    [SerializeField] private AliveEnemies aliveEnemies;

    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    //displays amount of alive enemies
    void Update()
    {
        text.SetText("Enemies left: " + aliveEnemies.EnemiesCount());
    }
}
