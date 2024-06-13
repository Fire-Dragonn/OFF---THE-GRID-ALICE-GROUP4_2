using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScript : MonoBehaviour
{
    public GameObject controller;
    public GameObject moveplate;

    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Sprite redToken;
    public Sprite BlueToken;
    public Sprite NeutralToken;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        /*if (controller == null)
        {
            Debug.LogError("GameController not found!");
            return;
        }
        // Ensure coordinates are set
        if (xBoard == -1 || yBoard == -1)
        {
            Debug.LogError("Coordinates not set for token!");
            return;
        }*/

        SetCoords();

        switch (this.name)
        {
            case "redToken": this.GetComponent<SpriteRenderer>().sprite = redToken; player = "Red"; break;

            case "BlueToken": this.GetComponent<SpriteRenderer>().sprite = BlueToken; player = "Blue"; break;

            case "NeutralToken": this.GetComponent<SpriteRenderer>().sprite = NeutralToken; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        float xPos = xBoard * 1f;//0.66f + -2.3f;
        float yPos = yBoard * 1f;//0.66f + -2.3f;

        this.transform.position = new Vector3(xPos, yPos, -1);
    }
   /* public void SetPlayer(string player)
    {
        this.player = player;
    }

    public string GetPlayer()
    {
        return player;
    }*/
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

    private void OnMouseUp()
    {
        Destroymoveplates();

        IntantiateMovePlates();
    }

    public void Destroymoveplates()
    {
        GameObject[] moveplates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; 1 < moveplates.Length; i++)
        {
            Destroy(moveplates[i]);
        }
    }

    public void IntantiateMovePlates()
    {
        switch (this.name) 
        {
            case "RedToken":
            case "BlueToken":
            case "NeutralToken":
                LineMovePlate(1,0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
        }

    }

    public void LineMovePlate(int xin, int yin)
    {
        NewGamescript sc = controller.GetComponent<NewGamescript>();

        if (sc.positiononboard(xin, yin))
        {
            if (sc.GetPosition(xin,yin) == null)
            {
                MovePlateSpawn(xin, yin);
            }

            //if (sc.GetPosition(xin +1,yin) && sc.GetPosition(xin+1,yin) !=null && sc.GetPosition(xin+1,y).GetComponent<TokenScript>().player != player)
        }

        /*int x = xBoard + xin;
        int y = yBoard + yin;

        while (sc.positiononboard(x, y) && sc.GetPosition(x,y) == null)
        {
            MovePlateSpawn(x, y);
            x += xin;
            y += yin;
        }*/

        /*if (sc.positiononboard(x,y) && sc.GetPosition(x,y).GetComponent<TokenScript>().player != player)
        {

        }*/ 
    }

    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1f;
        y *= 1f;

        GameObject mp = Instantiate(moveplate, new Vector3(x,y,-3), Quaternion.identity);

        MOveplate mpScript = mp.GetComponent<MOveplate>();
        mpScript.SetReference(gameObject);
        mpScript.setCoordsmp(matrixX, matrixY);
    }
}
