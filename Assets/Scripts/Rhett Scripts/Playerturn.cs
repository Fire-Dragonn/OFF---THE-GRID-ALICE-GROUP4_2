using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Playerturn : MonoBehaviour
{
   
    public GameObject player1;
    public GameObject player2;

    public bool Player1turn = true;
    public bool Player2turn = false;

    public int PlayerTurnCounter = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player1turn = true;
            Player2turn = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Player1turn = false;
            Player2turn = true;
        }

        if (Player1turn)
        {
            player1.SetActive(true);
            player2.SetActive(false);
        }
        else if (Player2turn)
        {
            player2.SetActive(true);
            player1.SetActive(false);
        }
    }

    public string GetCurrentPlayer()
    {
        return Player1turn ? "Red" : "Blue";
    }

    public void SwitchPlayer()
    {
        Player1turn = !Player1turn;
        Player2turn = !Player2turn;
    }
}
