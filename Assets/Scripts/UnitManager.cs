using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private List<ScriptableUnit> _units;

    public HerosBase SelectedHero;

    private void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void spawnHeros()
    {
        var heroCount = 1;

        for (int i = 0; i < heroCount; i++)
        {
            var randomPrefab = GetRandomUnit<HerosBase>(Faction.Heros);
            var spawnHero = Instantiate(randomPrefab);
            var RandomSpawnCase = CarteManager.Instance.GetHerosSpawnCase();

            RandomSpawnCase.SetUnit(spawnHero);
        }

        GameManager.Instance.ChangeState(GameState.SpawnEnnemis);
    }

    public void spawnEnnemis()
    {
        var ennemisCount = 1;

        for (int i = 0; i < ennemisCount; i++)
        {
            var randomPrefab = GetRandomUnit<EnnemisBase>(Faction.Ennemis);
            var spawnEnnemis = Instantiate(randomPrefab);
            var RandomSpawnCase = CarteManager.Instance.GetEnnemisSpawnCase();

            RandomSpawnCase.SetUnit(spawnEnnemis);
        }

        GameManager.Instance.ChangeState(GameState.TourHero);
    }

    private T GetRandomUnit<T>(Faction faction) where T : UniteBase
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedHero(HerosBase hero)
    {
        SelectedHero = hero;
        MenuManager.Instance.ShowSelectedHero(hero);
    }
}
