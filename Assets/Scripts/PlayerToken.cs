using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToken : MonoBehaviour
{
    private Vector2 targetPosition;
    private bool isMoving = false;
    private bool isPlayer1Turn = true; // Player 1 starts first

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Move towards the target position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);

            // Check if reached the target position
            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
        else
        {
            // Check for input only when not moving
            if (Input.GetMouseButtonDown(0))
            {
                // Cast a ray to detect which grid tile is clicked
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null && hit.collider.CompareTag("GridTile"))
                {
                    // Check if the tile is empty or occupied by an opponent
                    if (hit.collider.GetComponent<GridTile>().IsOccupiedByOpponent(isPlayer1Turn))
                    {
                        // Move to the clicked tile if it's valid
                        MoveToTile(hit.collider.gameObject);
                    }
                }
            }
        }
    }

    void MoveToTile(GameObject tile)
    {
        targetPosition = tile.transform.position;
        isMoving = true;
        tile.GetComponent<GridTile>().OccupyTile(isPlayer1Turn);
        // Switch turns after moving
        isPlayer1Turn = !isPlayer1Turn;
    }
}
