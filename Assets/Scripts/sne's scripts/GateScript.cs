using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public string gateOwner; // "Red" or "Blue"

    void OnTriggerEnter2D(Collider2D other)
    {
        TokenScript token = other.GetComponent<TokenScript>();
        if (token != null && token.tag == gateOwner + "token")
        {
            NewGamescript gameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<NewGamescript>();
            gameScript.CheckForPointsAndWin(token.GetPlayer(), token.GetxBoard(), token.GetyBoard());
            Destroy(other.gameObject);
        }
    }
}
