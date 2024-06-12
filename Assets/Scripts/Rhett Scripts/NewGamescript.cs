using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGamescript : MonoBehaviour
{
    public GameObject RedToken;

    private GameObject[,] positions = new GameObject[6, 6];
    private GameObject[] playerRed = new GameObject[5];
    private GameObject[] playerBlue = new GameObject[5];

    private string currentplayer = "Red";

    private bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(RedToken, new Vector3 (0,0,0), Quaternion.identity);
        playerRed = new GameObject[]
        {
            Create("RedToken", 0, 0 ,1) 
        };
        playerBlue = new GameObject[]
        {
            Create("BlueToken", 0, 0 ,1)
        };

        for (int i =0; 1 < playerRed.Length; i++)
        {
            SetPosition(playerRed[i]);
            SetPosition(playerBlue[i]);
        }
    }

    public GameObject Create(string name, int x, int y, int z)
    {
        GameObject obj = Instantiate(RedToken, new Vector3(0,0,1), Quaternion.identity);
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
   
}
