using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class CarteManager : MonoBehaviour
{
    public static CarteManager Instance;
    [SerializeField] private int _width, _height;

    [SerializeField] private Case _caseHerbe, _caseMontagne;

    [SerializeField] private Transform _camera;

    private Dictionary<Vector2, Case> _cases;

    private void Awake()
    {
        Instance = this;
    }

    public void GenerateCarte()
    {
        _cases = new Dictionary<Vector2, Case>();
        for (int x = 0; x < _width; x++){
            for (int y = 0;y < _height; y++){
                var randomCase = Random.Range(0, 6) == 3 ? _caseMontagne : _caseHerbe;
                var spawnnedCase = Instantiate(randomCase, new Vector3(x, y), Quaternion.identity);
                spawnnedCase.name = $"Case {x} {y}";

                spawnnedCase.Init(x,y);

                _cases[new Vector2(x, y)] = spawnnedCase;
            }
        }

        _camera.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);

        GameManager.Instance.ChangeState(GameState.SpawnHeros);
    }

    public Case GetHerosSpawnCase()
    {
        return _cases.Where(t => t.Key.x < _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Case GetEnnemisSpawnCase()
    {
        return _cases.Where(t => t.Key.x > _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Case GetCaseAtPosition(Vector2 pos)
    {
        if(_cases.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
}
