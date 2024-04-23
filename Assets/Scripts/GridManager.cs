using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>();
    private bool isPlayer1Turn = true;

    private Vector2 mouseOver;



    private void Start()
    {
        GenerateGrid();
    }
    public  void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);


                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
        GameManager.Instance.ChangeState(GameState.SpawnPlayer1tokens);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }
    public bool CanMoveToTile(Vector2 pos)
    {
        Tile tile = GetTileAtPosition(pos);
        if (tile != null)
        {
            return !tile.IsOccupied() || tile.IsOccupiedByOpponent(isPlayer1Turn);
        }
        return false;
    }


    public void OccupyTile(Vector2 pos)
    {
        Tile tile = GetTileAtPosition(pos);
        if (tile != null)
        {
            tile.OccupyTile(isPlayer1Turn);
        }
    } 
    public void SwitchPlayerTurn()
    {
        isPlayer1Turn = !isPlayer1Turn;
    }

}

/*References for part of the code:  https://youtu.be/kkAjpQAM-jE?si=oLZE6BqshD5zm2Al8 */

