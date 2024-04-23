using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    private bool isOccupied = false;
    private bool isPlayer1Token = false;

    public void OccupyTile(bool isPlayer1Turn)
    {
        // Occupy the tile with the player's token
        isOccupied = true;
        isPlayer1Token = isPlayer1Turn;
    }

    public bool IsOccupiedByOpponent(bool isPlayer1Turn)
    {
        // Check if the tile is not occupied or occupied by an opponent
        return !isOccupied || (isOccupied && isPlayer1Token != isPlayer1Turn);
    }
}
