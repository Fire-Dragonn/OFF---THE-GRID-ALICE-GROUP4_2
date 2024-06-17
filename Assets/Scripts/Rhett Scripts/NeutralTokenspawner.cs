using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralTokenspawner : MonoBehaviour
{
    public GameObject NeutralTokens;

    private GameObject[] playerneutral = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        playerneutral = new GameObject[]
         {
            Create(NeutralTokens, 3, 5),
            Create(NeutralTokens, 5, 3),
            Create(NeutralTokens, 1, 1),
            Create(NeutralTokens, -1, -1),
            Create(NeutralTokens, -5, -3),
            Create(NeutralTokens, -3, -5)
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
