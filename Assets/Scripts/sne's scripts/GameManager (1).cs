using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool hasGameFinished, canMove;
    string gameState;

    Player currentPlayer;

    public GameObject myBoard;

    public static GameManager instance;
    private TokenControl tokenControl;

    public delegate void UpdateMessage(Player player, string temp);
    public event UpdateMessage Message;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
        gameState = Constants.CLICK;
        canMove = false;
        hasGameFinished = false;
        currentPlayer = Player.RED;

        tokenControl = GetComponent<TokenControl>();
       

        // UIControl.instance.UpdateTurnIndicator(currentPlayer);
    }
    private void Start()
    {
        Message?.Invoke(currentPlayer, Constants.CLICK);
    }

    
   private Dictionary<GamePiece, List<Moves>> playerMoves;
    private bool isCapturedMove;


    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
   

    
}
