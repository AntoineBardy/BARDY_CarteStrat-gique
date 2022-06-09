using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseHerbe : Case
{
    [SerializeField] private Color _baseColor, _offsetColor;

    public override void Init(int x, int y)
    {
        var IsOffset = (x + y) %  2 == 1;
        _renderer.color = IsOffset ? _offsetColor : _baseColor;
    }
}
