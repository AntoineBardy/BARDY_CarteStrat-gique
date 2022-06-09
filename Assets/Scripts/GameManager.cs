using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ChangeState(GameState.GenerateCarte);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateCarte:
                CarteManager.Instance.GenerateCarte();
                break;
            case GameState.SpawnHeros:
                UnitManager.Instance.spawnHeros();
                break;
            case GameState.SpawnEnnemis:
                UnitManager.Instance.spawnEnnemis();
                break;
            case GameState.TourHero:
                break;
            case GameState.TourEnnemis:
                break;
            default:
                break;
        }
    }
}

public enum GameState
{
    GenerateCarte = 0,
    SpawnHeros = 1,
    SpawnEnnemis = 2,
    TourHero = 3,
    TourEnnemis = 4
}
