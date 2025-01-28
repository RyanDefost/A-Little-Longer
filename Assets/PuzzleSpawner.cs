using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
    [SerializeField] List<Sprite> _sprites;
    [SerializeField] Texture2D _spriteTexture;
    [Space]
    [SerializeField] GameObject _basePuzzlePiece;
    void Start()
    {
        GetSprites();

        for (int i = 0; i < _sprites.Count; i++)
        {
            _basePuzzlePiece.GetComponent<SpriteRenderer>().sprite = _sprites[i];

            var randomXpos = Random.Range(-5f, 5f);
            var randomYpos = Random.Range(-2.5f, 2.5f);
            var randomPosition = new Vector3(randomXpos, randomYpos, 0);
            _basePuzzlePiece.transform.position = randomPosition;

            Instantiate(_basePuzzlePiece);
        }
    }

    private void GetSprites()
    {
        Object[] data = Resources.LoadAll("WeirdClock");
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
}
