using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TokenControl : MonoBehaviour
{
    [SerializeField]
    private GameObject token;

    [SerializeField]
    private GameObject highlightPrefab;

    private Dictionary<GamePiece, GameObject> pieceDictionary;
    private GameObject highlightInstance;

    private void Awake()
    {
        pieceDictionary = new Dictionary<GamePiece, GameObject>();
    }

    public void InitializePieces()
    {
        int redPieceCount = 0;
        int bluePieceCount = 0;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if ((i + j) % 2 != 0 && j < 2 && redPieceCount < 5)
                {
                    CreatePiece(i, j, Player.RED, ref redPieceCount);
                }
                else if ((i + j) % 2 != 0 && j > 3 && bluePieceCount < 5)
                {
                    CreatePiece(i, j, Player.BLUE, ref bluePieceCount);
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        // Get the grid position based on the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Grid grid = new Grid() { x = (int)(mousePos.x + 0.5f), y = (int)-(mousePos.y - 0.5f) };

        // Highlight the grid block
        HighlightGrid(grid);
    }

    private void CreatePiece(int x, int y, Player player, ref int pieceCount)
    {
        GamePiece newPiece = new GamePiece(player, pieceCount++);
        GameObject pieceObject = Instantiate(token);
        pieceObject.transform.position = new Vector3(x, -y, -2f);
        pieceObject.GetComponent<SpriteRenderer>().color = player == Player.RED ? Color.red : Color.blue;
        pieceDictionary[newPiece] = pieceObject;

        UnityEngine.Debug.Log($"Created {player} piece at ({x}, {y})");
    }

    public GamePiece GetPieceAtGrid(Grid grid)
    {
        foreach (var pair in pieceDictionary)
        {
            Vector3 position = pair.Value.transform.position;
            Debug.Log($"Piece Position: ({position.x}, {position.y}), Grid Position: ({grid.x}, {grid.y})"); // Debug log for position comparison
            if ((int)position.x == grid.x && (int)-position.y == grid.y)
            {
                return pair.Key;
            }
        }
        return null;
    }

    public void MovePiece(GamePiece piece, Grid newGrid, bool isCapture, GamePiece capturedPiece)
    {
        if (pieceDictionary.ContainsKey(piece))
        {
            pieceDictionary[piece].transform.position = new Vector3(newGrid.x, -newGrid.y, -2f);
            if (isCapture)
            {
                pieceDictionary[capturedPiece].SetActive(false);
                pieceDictionary.Remove(capturedPiece);
            }
        }
    }

    public void HighlightGrid(Grid grid)
    {
        if (highlightInstance != null)
        {
            Destroy(highlightInstance);
        }
        highlightInstance = Instantiate(highlightPrefab, new Vector3(grid.x, -grid.y, -1f), Quaternion.identity);
    }

    public void ClearHighlight()
    {
        if (highlightInstance != null)
        {
            Destroy(highlightInstance);
        }
    }
    public void RemovePiece(GamePiece piece)
    {
        if (pieceDictionary.ContainsKey(piece))
        {
            Destroy(pieceDictionary[piece]);
            pieceDictionary.Remove(piece);
        }
    }

    public List<GamePiece> GetAllPieces()
    {
        return new List<GamePiece>(pieceDictionary.Keys);
    }

}



