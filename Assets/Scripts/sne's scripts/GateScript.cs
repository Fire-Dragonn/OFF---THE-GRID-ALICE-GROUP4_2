using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject token = collision.gameObject;

        // Check if the entering token is a player token or neutral token
        if (token.CompareTag("Player1token") || token.CompareTag("Player2token") || token.CompareTag("NeutralToken"))
        {
            TokenScript tokenScript = token.GetComponent<TokenScript>();
            if (tokenScript != null)
            {
                string player = tokenScript.GetPlayer();

                // Determine win/lose conditions based on player and gate position
                if (player == "Red" && gameObject.name == "RedGate")
                {
                    // Red player wins
                    NewGamescript.Instance.DisplayWinPanel("Red");
                }
                else if (player == "Blue" && gameObject.name == "BlueGate")
                {
                    // Blue player wins
                    NewGamescript.Instance.DisplayWinPanel("Blue");
                }
            }
        }
    }
}
