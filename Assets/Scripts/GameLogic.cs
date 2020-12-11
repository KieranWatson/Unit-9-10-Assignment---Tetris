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

    //grid restets and addes the prievous piece to the board so others collide with it.
    public Transform[,] grid = new Transform[width, height];

    //Spawn point for the pieces.
    public Transform spawnPos;

    int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBlock();
    }

    public void ClearLines()
    {
        for(int y = 0; y < height; y++)
        {
            if(IsLineComplete(y))
            {
                DestroyLine(y);
                MoveLines(y);
            }
        }
    }

    bool IsLineComplete(int y)
    {
        for(int x = 0; x < width; x++)
        {
            if(grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    void MoveLines(int y)
    {
        //The array goes out of bounds if you don't set -1
        //Since you check for the grid above in the second for loop
        for (int i = y; i < height - 1; i++) 
        {
            for (int x = 0; x < width; x++)
            {
                //In the tutors code, the code only checks for the row above, now it checks every row
                if (grid[x, i + 1] != null)
                {
                    grid[x, i] = grid[x, i + 1];
                    grid[x, i].gameObject.transform.position -= new Vector3(0, 1, 0);
                    grid[x, i + 1] = null;
                }
            }
        }
    }

    void DestroyLine(int y)
    {
        //Setting the cleared grid to null, then MoveLines will correct this if it got blocks above
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void SpawnBlock()
    {
        randomInt = Random.Range(0, blocks.Length);
        Instantiate(blocks[randomInt], spawnPos.position, spawnPos.rotation);
    }
}
