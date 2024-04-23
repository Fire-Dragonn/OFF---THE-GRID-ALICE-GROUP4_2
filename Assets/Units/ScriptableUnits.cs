using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName ="Scriptable Unit")]
public class ScriptableUnits : ScriptableObject
{
    public Players players;
}
public enum Players
{
    Player1Red = 0,
    Player2Blue=1
}