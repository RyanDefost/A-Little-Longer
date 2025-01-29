using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private ScoreBoard score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindAnyObjectByType<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "SCORE: " + score.GetScore();
    }
}
