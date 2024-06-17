using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueTokenspawner : MonoBehaviour
{
    public GameObject blueTokenPrefab;

    private GameObject[] playerBlue = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        playerBlue = new GameObject[]
         {
            Create(blueTokenPrefab, -1, 5),
            Create(blueTokenPrefab, -3, 5),
            Create(blueTokenPrefab, -3, 3),
            Create(blueTokenPrefab, -5, 3),
            Create(blueTokenPrefab, -5, 1)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
