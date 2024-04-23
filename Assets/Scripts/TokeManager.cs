using System.Collections.Generic;
using UnityEngine;

public class TokenManager: MonoBehaviour
{
    public static TokenManager instance;

    [SerializeField] private GameObject player1TokenPrefab;
    [SerializeField] private GameObject player2TokenPrefab;
    [SerializeField] private Transform spawnPoint;

    private List<GameObject> tokensOnBoard = new List<GameObject>();
    private int maxTokensOnBoard = 20;
    private bool isGameStarted = false;

    private bool hasSpawnedPlayer1Tokens = false;
    private bool hasSpawnedPlayer2Tokens = false;

    void Awake()
    {
        instance = this;
    }

    public void SpawnPlayerTokens()
    {
        if (!isGameStarted)
        {
            GameObject newToken = Instantiate(player1TokenPrefab, spawnPoint.position, Quaternion.identity);
            tokensOnBoard.Add(player1TokenPrefab);
        }
        isGameStarted = true;
       // GameManager.Instance.StartGame(); }

       
    }
public void RemoveToken(GameObject token)
{
    tokensOnBoard.Remove(token);
    Destroy(token);
    CheckGameStatus();
}

private void CheckGameStatus()
{
    if (tokensOnBoard.Count == 0)
    {
        isGameStarted = false;
    }
}

}