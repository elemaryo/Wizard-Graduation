using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public class Count
    {
        public int min;
        public int max;

        public Count (int mn, int mx){
            min = mn;
            max = mx;
        }
    }

    public int columns = 8;
    public int rows = 8;
    public Count wallCount = new Count (5,9);
    //public Count drops = new Count (1,3);
    public GameObject chest;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] enemyTiles;
    //public GameObject[] environmentTiles;

    private Transform boardHolder;
    //Possible grid positions
    private List<Vector3> grid = new List<Vector3>();

    //Clear list of grid positions
    void InitialiseList()
    {
        grid.Clear();

        //Add list of possible positions to place tiles
        for (int i = 1; i < columns - 1; i++)
        {
            for (int j = 1; j < rows - 1; j++)
            {
                grid.Add(new Vector3(i,j,0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject ("Board").transform;

        for (int i = -1; i < columns + 1; i++)
        {
            for (int j = -1; j < rows + 1; j++)
            {
               //Initialize tiles based on grid positions
               GameObject tile = floorTiles[Random.Range (0, floorTiles.Length)];
               if ((i == -1) || (i == columns) || j == -1 || j == rows)
               {
                    tile = wallTiles[Random.Range (0, wallTiles.Length)];
               }
               GameObject instance = Instantiate(tile, new Vector3 (i,j,0f), Quaternion.identity) as GameObject;
               instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, grid.Count);
        Vector3 randomPosition = grid[randomIndex];
        //Avoid duplicates
        grid.RemoveAt(randomIndex);
        return randomPosition;
    }

    void RandomGenerate(GameObject[] tileArray, int min, int max)
    {
        //Number of objects to create
        int objCount = Random.Range (min, max + 1);
        for (int i = 0; i < objCount; i++)
        {
            Vector3 randomPos = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
            Instantiate (tileChoice, randomPos, Quaternion.identity);
        }
    }
    
    public void SetUpScene(int level)
    {
        Player sc = gameObject.AddComponent<Player>() as Player;
        BoardSetup();
        InitialiseList();
        RandomGenerate(enemyTiles, 1, 4);
        //Scale number of enemies based on level
        //int enemyCount = (int)Mathf.Log(level, 2f);
        Instantiate(chest, new Vector3 (columns -1, rows -1, 0f), Quaternion.identity);
    }
}
