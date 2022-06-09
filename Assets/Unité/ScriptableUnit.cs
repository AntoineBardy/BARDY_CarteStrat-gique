using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Nouvelle Unit", menuName ="Scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction Faction;
    public UniteBase UnitPrefab;
}


public enum Faction
{
    Heros = 0,
    Ennemis = 1
}