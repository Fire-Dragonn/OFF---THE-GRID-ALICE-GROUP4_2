using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Playerturn : MonoBehaviour
{
    /* public Text player1;
     public Text player2;*/
    public GameObject player1;
    public GameObject player2;

    public bool Player1turn = true;
    public bool Player2turn = false;

    public int PlayerTurnCounter = 0;

    private void Start()
    {
        player1.SetActive(true);
    }
    private void Update()
    {
        //Debug.Log(PlayerTurnCounter);
        if (PlayerTurnCounter/2 > 0)
        {
            player1.SetActive(true);
            player2.SetActive(false);
        }
        else
        {
            player2.SetActive(true);
            player1.SetActive(false);
        }
    }
}
