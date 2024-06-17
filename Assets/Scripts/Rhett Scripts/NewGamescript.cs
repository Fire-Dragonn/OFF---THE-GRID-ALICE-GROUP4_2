using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGamescript : MonoBehaviour
{
    public GameObject redTokenPrefab;
    public GameObject blueTokenPrefab;

    public GameObject winPanel;
    public GameObject losePanel;

    public GameObject quitButton;

    public int redScore = 0;
    public int blueScore = 0;

    public TMP_Text redScoreText;
    public TMP_Text blueScoreText;

    private const int BoardSize = 11; // from -5 to 5 inclusive, we need 11 slots
    private const int Offset = 5; // to transform -5..5 to 0..10

    private GameObject[,] positions = new GameObject[BoardSize, BoardSize];

    private Playerturn playerTurnManager;

    private GameObject[] playerRed = new GameObject[5];
    private GameObject[] playerBlue = new GameObject[5];

    private string currentplayer = "Red";

    public bool gameOver = false;
    
    void Start()
    {
        playerTurnManager = GetComponent<Playerturn>();

       if (playerTurnManager == null)
        {
            Debug.LogError("Playerturn component not found on the GameController object.");
            return;
        }

        // Ensure quitButton is assigned in the Unity Editor
        if (quitButton != null)
        {
            // Add listener for the quit button click event
            quitButton.GetComponent<Button>().onClick.AddListener(QuitGame);
        }

        playerRed = new GameObject[]
        {
            Create(redTokenPrefab, 1, -5),
            Create(redTokenPrefab, 3, -5),
            Create(redTokenPrefab, 3, -3),
            Create(redTokenPrefab, 5, -3),
            Create(redTokenPrefab, 5, -1)
        };

        playerBlue = new GameObject[]
        {
            Create(blueTokenPrefab, -1, 5),
            Create(blueTokenPrefab, -3, 5),
            Create(blueTokenPrefab, -3, 3),
            Create(blueTokenPrefab, -5, 3),
            Create(blueTokenPrefab, -5, 1)
        };

         for (int i = 0; i < playerRed.Length; i++)
         {
            SetPosition(playerRed[i], playerRed[i].GetComponent<TokenScript>().GetxBoard(), playerRed[i].GetComponent<TokenScript>().GetyBoard());
            SetPosition(playerBlue[i], playerBlue[i].GetComponent<TokenScript>().GetxBoard(), playerBlue[i].GetComponent<TokenScript>().GetyBoard());
        }
        UpdateScoreText();
    }

    public GameObject Create(GameObject prefab, int x, int y)
    {
        GameObject obj = Instantiate(prefab, new Vector3(x,y,1), Quaternion.identity);
        TokenScript cm = obj.GetComponent<TokenScript>();
        cm.name = name;
        cm.SetxBoard(x);
        cm.SetyBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj, int x, int y)
    {
        if (positiononboard(x, y))
        {
            int arrayX = TransformCoordinate(x);
            int arrayY = TransformCoordinate(y);
            positions[arrayX, arrayY] = obj;
        }
        else
        {
            Debug.LogError($"Attempted to set a token at invalid position ({x}, {y})");
        }
    }
   
    public void setpositionempty(int x, int y)
    {
        if (positiononboard(x, y))
        {
            int arrayX = TransformCoordinate(x);
            int arrayY = TransformCoordinate(y);
            positions[arrayX, arrayY] = null;
        }
        else
        {
            Debug.LogError($"Attempted to empty an invalid position ({x}, {y})");
        }
    }

    public GameObject GetPosition(int x, int y)
    {
        if (positiononboard(x, y))
        {
            int arrayX = TransformCoordinate(x);
            int arrayY = TransformCoordinate(y);
            return positions[arrayX, arrayY];
        }
        return null;
    }

    public bool positiononboard(int x, int y)
    {
        return x >= -Offset && y >= -Offset && x <= Offset && y <= Offset;
    }

    private int TransformCoordinate(int coordinate)
    {
        return coordinate + Offset;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void SwitchPlayer()
    {
        if (playerTurnManager != null)
        {
            playerTurnManager.SwitchPlayer();
        }
        else
        {
            Debug.LogError("Playerturn component reference is missing.");
        }
    }

    public void EndGame()
    {
        gameOver = true;
    }



    public void CheckForPointsAndWin(string player, int x, int y)
    {
        // Assuming the gates are at (5,5) and (-5,-5)
        bool reachedGate = (player == "Red" && x == 5 && y == 5) || (player == "Blue" && x == -5 && y == -5);

        if (reachedGate)
        {
            if (player == "Red" && y == 5)
            {
                redScore++;
                if (redScore == 5)
                {
                    DisplayWinPanel(player);
                }
            }
            else if (player == "Blue" && y == -5)
            {
                blueScore++;
                if (blueScore == 5)
                {
                    DisplayWinPanel(player);
                }
                UpdateScoreText();
            }
        }
    }

    private void UpdateScoreText()
    {
        redScoreText.text = $"Red Score: {redScore}";
        blueScoreText.text = $"Blue Score: {blueScore}";
    }

    private void DisplayWinPanel(string winner)
    {
        gameOver = true;
        winPanel.SetActive(true);
        if (winner == "Red")
        {
            // Set win and lose texts appropriately
            winPanel.SetActive(true);
        }
        else
        {
            // Set win and lose texts appropriately
            if(winner == "Blue")
            {
                winPanel.SetActive(false);
                losePanel.SetActive(true);
            }
        }
    }
    public void QuitGame()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    internal string GetCurrentPlayer()
    {
        throw new NotImplementedException();
    }
}
