using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;
    private bool isPlayer1Turn = true;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
          /*  case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;*/

            case GameState.SpawnPlayer1tokens: TokenManager.
                    instance.SpawnPlayerTokens();
                break;
            case GameState.SpawnPlayer2tokens:
                TokenManager.instance.SpawnPlayerTokens();
                break;

           /* case GameState.Spawnplayer1Blocktokens:
                    TokenManager.instance.SpawnPlayer1Blocktokens();
                break;
                case GameState.Spawnplayer2Blocktokens:
                TokenManager.instance.SpawnPlayer1Blocktokens();
                break; */

            case GameState.Player1Turn:
                //set up ui to indicate player turn
                isPlayer1Turn = true;
                break;
            case GameState.Player2Turn:
                //set up UI
                isPlayer1Turn=false;
                break;
           /* default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);*/
        }
    }
    public void EndTurn()
    {
        if (isPlayer1Turn)
        {
            ChangeState(GameState.Player2Turn);
        }
        else
        {
            ChangeState(GameState.Player1Turn);
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnPlayer1tokens = 1,
    SpawnPlayer2tokens = 2,
    Spawnplayer1Blocktokens= 3,
    Spawnplayer2Blocktokens= 4,
    Player1Turn = 5,
    Player2Turn = 6
}
