using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NeutralTokenspawner : MonoBehaviour
{
    public GameObject NeutralTokens;
    private GameObject[] playerneutral = new GameObject[6];

    private int currentPlayerIndex = 0; // 0 for Player 1, 1 for Player 2
    private int movesMadeByPlayer1 = 0;
    private int movesMadeByPlayer2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerneutral = new GameObject[]
         {
            Create(NeutralTokens, 3, 5),
            Create(NeutralTokens, 5, 3),
            Create(NeutralTokens, 1, 1),
            Create(NeutralTokens, -1, -1),
            Create(NeutralTokens, -5, -3),
            Create(NeutralTokens, -3, -5)
         };
    }

    public GameObject Create(GameObject prefab, int x, int y)
    {
        GameObject obj = Instantiate(prefab, new Vector3(x, y, 1), Quaternion.identity);
        TokenScript cm = obj.GetComponent<TokenScript>();
        cm.name = name;
        cm.SetxBoard(x);
        cm.SetyBoard(y);
        cm.Activate();
        return obj;
    }

    /*public void OnMoveToken(GameObject token)
    {
        TokenScript tokenScript = token.GetComponent<TokenScript>();

        // Check if it's the current player's turn
        if ((currentPlayerIndex == 0 && movesMadeByPlayer1 < 2) ||
            (currentPlayerIndex == 1 && movesMadeByPlayer2 < 2))
        {
            // Allow the token to be moved
            tokenScript.OnMouseDown(); // Trigger the token's movement logic

            // Increment move count for the current player
            if (currentPlayerIndex == 0)
            {
                movesMadeByPlayer1++;
            }
            else
            {
                movesMadeByPlayer2++;
            }

            // Switch to the next player's turn after two moves
            if (movesMadeByPlayer1 == 2 && movesMadeByPlayer2 == 2)
            {
                EndTurn();
            }
        }
        else
        {
            Debug.Log("Cannot move more tokens this turn.");
        }
    }

    private void EndTurn()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % 2; // Switch players (0 -> 1, 1 -> 0)
        movesMadeByPlayer1 = 0;
        movesMadeByPlayer2 = 0;

        Debug.Log($"Player {currentPlayerIndex + 1}'s turn.");
    }*/

}
