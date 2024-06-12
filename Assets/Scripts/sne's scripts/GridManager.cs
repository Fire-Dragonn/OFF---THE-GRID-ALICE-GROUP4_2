using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gridSquarePrefab;

    [SerializeField]
    private int gridSize = 6;

    private Transform[,] gridArray;

    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        gridArray = new Transform[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject gridSquare = Instantiate(gridSquarePrefab, new Vector3(x, -y, 0), Quaternion.identity, this.transform);
                gridSquare.name = $"GridSquare_{x}_{y}";
                gridArray[x, y] = gridSquare.transform;
            }
        }
    }

    public Transform GetGridSquare(int x, int y)
    {
        if (x >= 0 && x < gridSize && y >= 0 && y < gridSize)
        {
            return gridArray[x, y];
        }
        return null;
    }
}
