using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGamescript : MonoBehaviour
{
    public GameObject RedToken;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(RedToken, new Vector3 (0,0,0), Quaternion.identity);
    }


   
}
