using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIControl : MonoBehaviour
{
    public static UIControl instance;

    [SerializeField] private TextMeshProUGUI turnText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateTurnIndicator(Player currentPlayer)
    {
        if (currentPlayer == Player.RED)
        {
            turnText.text = "Player 1's Turn (Red)";
            turnText.color = Color.red;
        }
        else if (currentPlayer == Player.BLUE)
        {
            turnText.text = "Player 2's Turn (Blue)";
            turnText.color = Color.blue;
        }
    }
}
