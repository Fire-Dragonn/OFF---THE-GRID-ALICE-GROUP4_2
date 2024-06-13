using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGamescript : MonoBehaviour
{
    /*public GameObject RedToken;
    public GameObject BlueToken;
    public GameObject NeutralToken;*/
    public GameObject Token;

    private GameObject[,] positions = new GameObject[6, 6];
    private GameObject[] playerRed = new GameObject[10];
    private GameObject[] playerBlue = new GameObject[10];

    private string currentplayer = "Red";

    private bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Token, new Vector3 (0,0,-1), Quaternion.identity);
        playerRed = new GameObject[]
        {
            Create("RedToken", 1, -5,1),Create("RedToken2", 3, -5,1),Create("RedToken3", 3, -3,1),Create("Redtoken4",5, -3,1),Create("Redtoken5",5, -1,1) 
        };
        playerBlue = new GameObject[]
        {
            Create("BlueToken", -1, 5 ,1),Create("Bluetoken2", -3, 5,1),Create("Bluetoken3", -3, 3, 1),Create("Bluetoken4", -5, 3,1),Create("BLuetoken5", -5, 1,1)
        };

        for (int i = 0; 1 < playerRed.Length; i++)
        {
            SetPosition(playerRed[i]);
            SetPosition(playerBlue[i]);
        }
    }

    public GameObject Create(string name, int x, int y, int z)
    {
        GameObject obj = Instantiate(Token, new Vector3(0,0,1), Quaternion.identity);
        TokenScript cm = obj.GetComponent<TokenScript>();
        cm.name = name;
        cm.SetxBoard(x);
        cm.SetyBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        TokenScript cm = obj.GetComponent<TokenScript>();

        positions[cm.GetxBoard(), cm.GetyBoard()] = obj;
    }
   
    public void setpositionempty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool positiononboard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }
}
