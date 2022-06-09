using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject _heroObjetSelect, _caseObjet, CaseUniteObjet;
    private void Awake()
    {
        Instance = this;
    }

    public void ShowCasesInfo()
    {
        _heroObjetSelect.GetComponentInChildren<Text>().text = cases.caseName;
        _heroObjetSelect.SetActive(true);

        if ()
    }
    public void ShowSelectedHero(HerosBase hero)
    {
        if(hero == null)
        {
            _heroObjetSelect.SetActive(false);
            return;
        }
        _heroObjetSelect.GetComponentInChildren<Text>().text = hero.UniteName;
        _heroObjetSelect.SetActive(true);
    }
}
