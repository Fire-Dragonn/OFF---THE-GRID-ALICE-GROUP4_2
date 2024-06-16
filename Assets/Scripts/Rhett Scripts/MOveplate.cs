using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOveplate : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;

    int matrixX;
    int matrixY;

    //True = movemnt
    public bool movement = true;

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        TokenScript ts = reference.GetComponent<TokenScript>();
        NewGamescript sc = ts.controller.GetComponent<NewGamescript>();

        sc.setpositionempty(ts.GetxBoard(), ts.GetyBoard());

        ts.SetxBoard(matrixX);
        ts.SetyBoard(matrixY);
        ts.SetCoords();

        //sc.SetPosition(reference);

      //  ts.Destroymoveplates();

       
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void setCoordsmp(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public GameObject Getreference()
    {
        return reference;
    }
} 
