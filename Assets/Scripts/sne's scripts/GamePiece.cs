using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece
{
    public Player Player { get; private set; }
    public int ID{ get; private set; }
    public int pieceNumber { get; private set; }

    public string pieceType;
    
    public GamePiece(Player player, int ID)
    {
        Player = player;
      //  ID = id;
    }

}
