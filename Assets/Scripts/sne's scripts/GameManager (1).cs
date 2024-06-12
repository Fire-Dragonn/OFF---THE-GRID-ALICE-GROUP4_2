using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool hasGameFinished, canMove;
    string gameState;

    Player currentPlayer;

    private GamePiece clickedPiece;

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

    // Update is called once per frame
    void Update()
    {
        if (hasGameFinished) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Grid clickedGrid = new Grid() { x = Mathf.RoundToInt(mousePos.x), y = Mathf.RoundToInt(mousePos.y) };

            switch (gameState)
            {
                case Constants.CLICK:
                    HandleClickState(clickedGrid);
                    break;

                case Constants.MOVE:
                    HandleMoveState(clickedGrid);
                    break;

                default:
                    break;
            }
        }
    }

    private void HandleClickState(Grid clickedGrid)
    {
        
        canMove = false;
        //clickedPiece = tokenControl.GetPieceAtGrid(clickedGrid);
       
       // CalculateMoves(currentPlayer);

        if (playerMoves.Count == 0)
        {
            hasGameFinished = true;
            Message(currentPlayer, Constants.FINISHED);
            return;
        }

        if (clickedPiece == null || clickedPiece.Player != currentPlayer || clickedPiece.pieceNumber == -1)
        {
            return;
        }

        if (playerMoves.ContainsKey(clickedPiece))
        {
            canMove = true;
           
        }

        if (!canMove) return;

        //tokenControl.HighlightGrid(clickedGrid);
        gameState = Constants.MOVE;
    }

    private void HandleMoveState(Grid clickedGrid)
    {
        // Logic for handling the move state
        List<Moves> moves = playerMoves[clickedPiece];

        foreach (var currentMove in moves)
        {
            /*  if (currentMove.end.x == clickedGrid.x && currentMove.end.y == clickedGrid.y)
              {
                  tokenControl.MovePiece(clickedPiece, clickedGrid, currentMove.isCapture, currentMove.capturedPiece);

                  UpdateMove(currentMove);
                  if (currentMove.end.y == 0 && currentPlayer == Player.RED)
                  {
                      tokenControl.RemovePiece(clickedPiece);
                  }
                  else if (currentMove.end.y == 5 && currentPlayer == Player.BLUE)
                  {
                      tokenControl.RemovePiece(clickedPiece);
                  } 
              }*/
            gameState = Constants.CLICK;


            currentPlayer = currentPlayer == Player.RED ? Player.BLUE : Player.RED;

            UIControl.instance.UpdateTurnIndicator(currentPlayer);

            Message(currentPlayer, Constants.CLICK);

            tokenControl.ClearHighlight();
        }
    }
    
  


   /* private void CalculateMoves(Player player)
    {
        playerMoves = new Dictionary<GamePiece, List<Moves>>();

        foreach (var piece in tokenControl.GetAllPieces())
        {
            if (piece.Player == player)
            {
                List<Moves> moves = new List<Moves>();
                playerMoves[piece] = moves;
            }
        }
    }*/

  /*  private void UpdateMove(Moves move)
    {
        // Logic for updating the board state after a move
    }*/
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
