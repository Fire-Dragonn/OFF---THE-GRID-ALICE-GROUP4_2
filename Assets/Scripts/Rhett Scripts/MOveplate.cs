using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOveplate : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;

    int matriX;
    int matriY;

    //True = movemnt
    public bool movement = true;

    public void Start()
    {

    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        GameObject tp = controller.GetComponent<NewGamescript>().GetPosition(matriX, matriY);

        Destroy(tp);

        controller.GetComponent<NewGamescript>().setpositionempty(reference.GetComponent<TokenScript>().GetxBoard(),
            reference.GetComponent<TokenScript>().GetyBoard());

        reference.GetComponent<TokenScript>().SetxBoard(matriX);
        reference.GetComponent<TokenScript>().SetyBoard(matriY);
        reference.GetComponent<TokenScript>().SetCoords();

        controller.GetComponent<NewGamescript>().SetPosition(reference);

        reference.GetComponent<TokenScript>().Destroymoveplates();
    }

    public void setCoordsmp(int x, int y)
    {
        matriX = x;
        matriY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject Getreference()
    {
        return reference;
    }
} 
