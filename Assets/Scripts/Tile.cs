using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    public bool isStartingzone;

    private bool isOccupied = false;
    private bool isPlayer1Token = false;

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : (isStartingzone ? _baseColor: _baseColor);
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public bool IsOccupiedByOpponent(bool isPlayer1Turn)
    {
        return isOccupied && isPlayer1Token != isPlayer1Turn;
    }

    public void OccupyTile(bool isPlayer1Turn)
    {
        isOccupied = true;
        isPlayer1Token = isPlayer1Turn;
    }

    internal bool isGateBlock()
    {
        throw new NotImplementedException();
    }

    void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

}