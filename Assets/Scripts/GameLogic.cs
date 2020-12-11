using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    //This will make the piece slowly fall to the floor when it is used.
    public static float dropTime = 0.9f;

    //This will make the piece fall faster when activated.
    public static float quickDropTime = 0.05f;

    //Board
    public static int width = 15, height = 30;

    //Stores the different pieces.
    public GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBlock()
    {
        float guess = Random.Range(0, 1f);
        guess *= blocks.Length;
        Instantiate(blocks[Mathf.FloorToInt(guess)]);
    }
}
