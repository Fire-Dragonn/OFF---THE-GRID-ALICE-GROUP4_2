using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BLuegate : MonoBehaviour
{
    public int bluenumber = 0;
    public Text bluetext;

    private string bluescore;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("score");
        bluenumber++;
        Debug.Log(bluenumber.ToString());
        bluescore = bluenumber.ToString();
        bluetext.text = bluescore;
    }
}
