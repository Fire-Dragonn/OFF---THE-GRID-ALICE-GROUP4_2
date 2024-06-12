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

    private GameObject selectedToken;
    private Vector3 originalPosition;
    private GameObject highlightInstance;
    private Dictionary<Vector2, GameObject> boardPositions; // Track occupied positions on the board


    private void Awake()
    {
        boardPositions = new Dictionary<Vector2, GameObject>();
        PopulateBoardPositions();


    }

    private void PopulateBoardPositions()
    {
        GameObject[] player1Tokens = GameObject.FindGameObjectsWithTag("Player1token");
        GameObject[] player2Tokens = GameObject.FindGameObjectsWithTag("Player2token");

        foreach (var token in player1Tokens)
        {
            Vector2 position = new Vector2(token.transform.position.x, token.transform.position.y);
            boardPositions[position] = token;
        }

        foreach (var token in player2Tokens)
        {
            Vector2 position = new Vector2(token.transform.position.x, token.transform.position.y);
            boardPositions[position] = token;
        }
    }

    private void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && (hit.collider.CompareTag("Player1token") || hit.collider.CompareTag("Player2token")))
            {
                selectedToken = hit.collider.gameObject;
                originalPosition = selectedToken.transform.position;
                HighlightGrid(selectedToken.transform.position);
            }
        }

        if (Input.GetMouseButton(0) && selectedToken != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedToken.transform.position = new Vector3(mousePos.x, mousePos.y, selectedToken.transform.position.z);
        }

        if (Input.GetMouseButtonUp(0) && selectedToken != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPosition = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

            if (IsValidMove(targetPosition))
            {
                MoveToken(selectedToken, targetPosition);
            }
            else
            {
                selectedToken.transform.position = originalPosition;
            }

            ClearHighlight();
            selectedToken = null;
        }
    }

    private bool IsValidMove(Vector2 targetPosition)
    {
        if (boardPositions.ContainsKey(targetPosition))
        {
            return false; // Position is already occupied
        }

        // Additional logic to validate the move can be added here

        return true;
    }

    private void MoveToken(GameObject token, Vector2 targetPosition)
    {
        Vector2 originalPos = new Vector2(originalPosition.x, originalPosition.y);
        boardPositions.Remove(originalPos);
        boardPositions[targetPosition] = token;
        token.transform.position = new Vector3(targetPosition.x, targetPosition.y, token.transform.position.z);
    }

    public void HighlightGrid(Vector3 position)
    {
        if (highlightInstance != null)
        {
            Destroy(highlightInstance);
        }

        highlightInstance = Instantiate(highlightPrefab, new Vector3(position.x, position.y, -1f), Quaternion.identity);
    }

    public void ClearHighlight()
    {
        if (highlightInstance != null)
        {
            Destroy(highlightInstance);
        }
    }


}



