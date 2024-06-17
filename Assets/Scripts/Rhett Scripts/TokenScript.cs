using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.GraphicsBuffer;

public class TokenScript : MonoBehaviour
{
    public GameObject controller;
    public GameObject moveplate;

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isDragging = false;

    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Playerturn counter;

    public Sprite redToken;
    public Sprite BlueToken;
    public Sprite NeutralToken;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        
        SetCoords();


        switch (this.tag)
        {
            case "Player1token": this.GetComponent<SpriteRenderer>().sprite = redToken; player = "Red"; break;

            case "Player2token": this.GetComponent<SpriteRenderer>().sprite = BlueToken; player = "Blue"; break;

            case "NeutralToken": this.GetComponent<SpriteRenderer>().sprite = NeutralToken; break;
        }


        
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        float xPos = xBoard * 1f;//0.66f + -2.3f;
        float yPos = yBoard * 1f;//0.66f + -2.3f;

        this.transform.position = new Vector3(xPos, yPos, 1);
    }
   
   public int GetxBoard()
    { return xBoard; }

   public int GetyBoard() 
    { return yBoard; }

   public void SetxBoard(int x)
    {
        xBoard = x;
    }
   public void SetyBoard(int y)
    {
        yBoard = y;
    }
    void OnMouseDown()
    {
        //if (controller.GetComponent<NewGamescript>().GetCurrentPlayer() == player && !controller.GetComponent<NewGamescript>().IsGameOver())
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            isDragging = true;
        }
        
    }
    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
        }
    }


    private void OnMouseUp()
    {

        if (isDragging)
        {
            isDragging = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int targetX = Mathf.RoundToInt(mousePos.x);
            int targetY = Mathf.RoundToInt(mousePos.y);

            NewGamescript sc = controller.GetComponent<NewGamescript>();

            // Check if the target position is within the board bounds and empty
            if (sc != null)
            {
                // Check if the target position is within bounds and empty
                if (sc.positiononboard(targetX, targetY) && sc.GetPosition(targetX, targetY) == null)
                {
                    // Calculate the center position of the target grid block
                    float targetCenterX = targetX;
                    float targetCenterY = targetY;

                    // Update token's board coordinates
                    // NewGamescript.setpositionempty(xBoard, yBoard);
                    xBoard = targetX;
                    yBoard = targetY;
                    SetCoords();

                    // Snap the token to the center of the target grid block
                    transform.position = new Vector3(targetCenterX, targetCenterY, transform.position.z);

                    // Set the token at the new position on the board
                    //sc.SetPosition(gameObject);

                }
                else
                {
                    // Handle invalid move (e.g., snap back to original position)
                    SnapToCenter(xBoard, yBoard);
                }
            }
            else
            {
                Debug.LogError("NewGameScript component not found on the controller object.");
            }
        }
    }
    void SnapToCenter(int targetX, int targetY)
    {
        float xPos = targetX * 1f;
        float yPos = targetY * 1f;

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}

    

    
