using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    private bool isSelected;
    //private bool canMove;
    private Vector3 originalPosition;

    public Player player;
    public bool isSpecialToken;
    private bool hasMoved; // For special tokens that can only move once

    private static Token selectedToken;

    private void Start()
    {
        isSelected = false;
        //canMove = false;
        hasMoved = false;
        originalPosition = transform.position;
    }
   // private GameObject highlightInstance;

    private void OnMouseEnter()
    {
        if (!hasMoved || !isSpecialToken)
        {
            // Highlight token to indicate it's selectable
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        if (!isSelected)
        {
            // Remove highlight
            GetComponent<SpriteRenderer>().color = player == Player.RED ? Color.red : Color.blue;
        }
    }

    private void OnMouseDown()
    {
        if (!hasMoved || !isSpecialToken)
        {
            if (selectedToken != null)
            {
                // Deselect the previously selected token
                selectedToken.isSelected = false;
                selectedToken.transform.position = selectedToken.originalPosition;
                selectedToken.GetComponent<SpriteRenderer>().color = selectedToken.player == Player.RED ? Color.red : Color.blue;
            }

            // Select the current token
            isSelected = true;
            selectedToken = this;
            GetComponent<SpriteRenderer>().color = Color.green; // Indicate selection
        }
    }

    private void OnMouseUp()
    {
        if (isSelected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Grid targetGrid = new Grid() { x = Mathf.RoundToInt(mousePos.x), y = Mathf.RoundToInt(mousePos.y) };

            // Check if the target grid is empty and within bounds
            if (IsValidMove(targetGrid))
            {
                MoveToGrid(targetGrid);
            }
            else
            {
                // Move back to the original position
                transform.position = originalPosition;
            }

            isSelected = false;
            selectedToken = null;
            GetComponent<SpriteRenderer>().color = player == Player.RED ? Color.red : Color.blue;
        }
    }
    private bool IsValidMove(Grid grid)
    {
        // Implement logic to check if the target grid is a valid move
        // This can include checking if the grid is within bounds, is empty, and follows the game rules
        // For now, let's assume the method IsGridEmpty(grid) checks if the grid is empty
        return IsGridEmpty(grid) && IsWithinBounds(grid);
    }

    private bool IsGridEmpty(Grid grid)
    {
        // Implement logic to check if the target grid is empty
        // This is a placeholder implementation
        return true;
    }

    private bool IsWithinBounds(Grid grid)
    {
        return grid.x >= 0 && grid.x < 6 && grid.y >= 0 && grid.y < 6;
    }

    private void MoveToGrid(Grid grid)
    {
        transform.position = new Vector3(grid.x, grid.y, -1);

        if (isSpecialToken)
        {
            hasMoved = true;
        }

        // Implement additional logic for capturing opponent tokens if necessary
    }
}
