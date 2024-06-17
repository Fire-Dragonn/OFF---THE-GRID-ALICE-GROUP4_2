using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class redgate : MonoBehaviour
{
    public int rednumber = 0;
    public Text redscore;

    private string redstring;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("score");
        rednumber++;
        Debug.Log(rednumber.ToString());
        redstring = rednumber.ToString();
        redscore.text = redstring;
    }
}
