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
        if (controller == null)
        {
            Debug.LogError("GameController not found!");
            return;
        }
        // Ensure coordinates are set
        if (xBoard == -1 || yBoard == -1)
        {
            Debug.LogError("Coordinates not set for token!");
            return;
        }

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

        float xPos = xBoard * 0.66f + -2.3f;
        float yPos = yBoard * 0.66f + -2.3f;

        this.transform.position = new Vector3(xPos, yPos, -1);
    }
    public void SetPlayer(string player)
    {
        this.player = player;
    }

    public string GetPlayer()
    {
        return player;
    }
}
