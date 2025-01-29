using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _score = 0;

    void Start()
    {
        _text.text = "SCORE: " + 0;
    }

    public void updateText()
    {
        _score++;
        _text.text = "SCORE: " + _score;
    }
}
