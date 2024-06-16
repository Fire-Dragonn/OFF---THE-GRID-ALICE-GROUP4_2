using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System;
using Debug = UnityEngine.Debug;

public class TokenControl : MonoBehaviour
{
    [SerializeField]
    private GameObject highlightPrefab;

    private Dictionary<Grid, Token> tokenDictionary;
    private GameObject highlightInstance;

    private void Awake()
    {
        tokenDictionary = new Dictionary<Grid, Token>();
    }

    public void InitializeTokens()
    {
        // Assume tokens are already placed on the board
        Token[] tokens = FindObjectsOfType<Token>();
        foreach (Token token in tokens)
        {
            Grid gridPosition = new Grid() { x = Mathf.RoundToInt(token.transform.position.x), y = Mathf.RoundToInt(token.transform.position.y) };
            tokenDictionary[gridPosition] = token;
        }
    }

    public Token GetTokenAtGrid(Grid grid)
    {
        tokenDictionary.TryGetValue(grid, out Token token);
        return token;
    }

    public void HighlightGrid(Grid grid)
    {
        if (highlightInstance != null)
        {
            Destroy(highlightInstance);
        }

        Vector3 highlightPosition = new Vector3(grid.x, grid.y, -1f);
        highlightInstance = Instantiate(highlightPrefab, highlightPosition, Quaternion.identity);
    }

    public void ClearHighlight()
    {
        if (highlightInstance != null)
        {
            Destroy(highlightInstance);
        }
    }

    public void MoveToken(Token token, Grid newGrid)
    {
        Grid oldGrid = new Grid() { x = Mathf.RoundToInt(token.transform.position.x), y = Mathf.RoundToInt(token.transform.position.y) };

        token.transform.position = new Vector3(newGrid.x, newGrid.y, -1f);
        tokenDictionary.Remove(oldGrid);
        tokenDictionary[newGrid] = token;
    }






}



