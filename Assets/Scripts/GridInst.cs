using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridInst : MonoBehaviour
{
    public int rows = 6;
    public int columns= 6;
    private float tileSize = 1;
    public Transform cam;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = GameObject.FindGameObjectWithTag("Grid tile");
        Vector3 cameraPosition = cam.transform.position;

        float startX = cameraPosition.x - (columns * tileSize) / 2f + tileSize / 2f;
        float startY = cameraPosition.y + (rows * tileSize) / 2f - tileSize / 2f;
        for (int row = 0; row < rows; row++)
        {
            for(int col = 0; col < columns; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile,cam);
                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2 (posX, posY);
            }
        }
        Destroy(referenceTile);
    }
}
