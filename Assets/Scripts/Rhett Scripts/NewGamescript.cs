using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGamescript : MonoBehaviour
{
    public GameObject redTokenPrefab;
/*    public GameObject blueTokenPrefab;*/
    //public GameObject NeutralToken;

    
    
    

    private GameObject[,] positions = new GameObject[6, 6];
    private GameObject[] playerRed = new GameObject[5];
    /*private GameObject[] playerBlue = new GameObject[5];*/

    private string currentplayer = "Red";

    public bool gameOver = false;
    
    void Start()
    {
        playerRed = new GameObject[]
        {
            Create(redTokenPrefab, 1, -5),
            Create(redTokenPrefab, 3, -5),
            Create(redTokenPrefab, 3, -3),
            Create(redTokenPrefab, 5, -3),
            Create(redTokenPrefab, 5, -1)
        };

        /*playerBlue = new GameObject[]
        {
            Create(blueTokenPrefab, -1, 5),
            Create(blueTokenPrefab, -3, 5),
            Create(blueTokenPrefab, -3, 3),
            Create(blueTokenPrefab, -5, 3),
            Create(blueTokenPrefab, -5, 1)
        };
*/
         for (int i = 0; i < playerRed.Length; i++)
         {
           // SetPosition(playerRed[i]);
            // SetPosition(playerBlue[i]);
         }
    }

    public GameObject Create(GameObject prefab, int x, int y)
    {
        GameObject obj = Instantiate(prefab, new Vector3(x,y,1), Quaternion.identity);
        TokenScript cm = obj.GetComponent<TokenScript>();
        cm.name = name;
        cm.SetxBoard(x);
        cm.SetyBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj, int x, int y)
    {
        TokenScript cm = obj.GetComponent<TokenScript>();
        cm.SetxBoard(x);
        cm.SetyBoard(y);

        positions[x, y] = obj;

        // positions[cm.GetxBoard(), cm.GetyBoard()] = obj;
    }
   
    public void setpositionempty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        if (positiononboard(x, y))
        {
            return positions[x, y];
        }
        return null;
    }

    public bool positiononboard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    
    public bool IsGameOver()
    {
        return gameOver;
    }
   


    public void EndGame()
    {
        gameOver = true;
    }

    internal string GetCurrentPlayer()
    {
        throw new NotImplementedException();
    }
}
