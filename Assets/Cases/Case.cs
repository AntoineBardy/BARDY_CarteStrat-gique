using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public string caseName;
    
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    [SerializeField] private bool _isWalkable;

    public UniteBase OccupiedUnit;
    public bool Walkable => _isWalkable && OccupiedUnit == null;

    public virtual void Init(int x, int y)
    {
        
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.GameState != GameState.TourHero) return;

        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.Faction == Faction.Heros) UnitManager.Instance.SetSelectedHero((HerosBase)OccupiedUnit);
            else
            {
                if(UnitManager.Instance.SelectedHero != null)
                {
                    var ennemie = (EnnemisBase)OccupiedUnit;
                    Destroy(ennemie.gameObject);
                    UnitManager.Instance.SetSelectedHero(null);
                }
            }
        }
        else
        {
            if(UnitManager.Instance.SelectedHero != null)
            {
                SetUnit(UnitManager.Instance.SelectedHero);
                UnitManager.Instance.SetSelectedHero(null);
            }
        }
    }

    public void SetUnit(UniteBase unites)
    {
        if (unites.OccupiedCase != null) unites.OccupiedCase.OccupiedUnit = null;
        unites.transform.position = transform.position;
        OccupiedUnit = unites;
        unites.OccupiedCase = this;
    }
}
