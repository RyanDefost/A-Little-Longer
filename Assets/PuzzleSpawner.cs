using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
    [SerializeField] List<Sprite> _sprites;
    [SerializeField] List<Texture2D> _spriteTexture;
    private int _currentPuzzle = 0;

    public List<GameObject> CurrentPieces = new List<GameObject>();
    [Space]
    [SerializeField] GameObject _basePuzzlePiece;
    void Start()
    {
        SetPuzzle();
    }

    private void SetPuzzle()
    {
        CurrentPieces.Clear();

        GetSprites();

        for (int i = 0; i < _sprites.Count; i++)
        {
            _basePuzzlePiece.GetComponent<SpriteRenderer>().sprite = _sprites[i];

            var randomXpos = Random.Range(-5f, 5f);
            var randomYpos = Random.Range(-2.5f, 2.5f);
            var randomPosition = new Vector3(randomXpos, randomYpos, 0);
            _basePuzzlePiece.transform.position = randomPosition;

            CurrentPieces.Add(Instantiate(_basePuzzlePiece));
        }
    }

    private void GetSprites()
    {
        Object[] data = Resources.LoadAll(_spriteTexture[_currentPuzzle].name);
        if (data != null)
        {
            foreach (Object obj in data)
            {
                if (obj.GetType() == typeof(Sprite))
                {
                    _sprites.Add(obj as Sprite);
                }
            }
        }
    }

    public void DestroyPieces()
    {
        foreach (var item in CurrentPieces)
        {
            Destroy(item);
        }

        _sprites.Clear();
    }

    public void NextPuzzle()
    {
        if (_currentPuzzle < _spriteTexture.Count - 1)
        {
            _currentPuzzle++;
        }
        else
        {
            _currentPuzzle = 0;
        }
        Debug.Log(_spriteTexture.Count);
        Debug.Log(_currentPuzzle);
        DestroyPieces();
        SetPuzzle();
    }
}
