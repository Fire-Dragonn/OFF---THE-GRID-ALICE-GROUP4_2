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

    public Sprite redToken, BlueToken, NeutralToken;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "redToken": this.GetComponent<SpriteRenderer>().sprite = redToken; break;
            case "BlueToken": this.GetComponent<SpriteRenderer>().sprite = BlueToken; break;
            case "NeutralToken": this.GetComponent<SpriteRenderer>().sprite = NeutralToken; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;
        
        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1);
    }
}
