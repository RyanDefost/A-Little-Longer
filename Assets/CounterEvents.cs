using UnityEngine;
using UnityEngine.UI;

public class CounterEvents : MonoBehaviour
{
    [SerializeField] private Button _button;
    public float PressAmount;

    [SerializeField] private Timer _timer;
    public float ElapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(ButtonPress);
    }

    private void Update()
    {
        ElapsedTime = _timer.GetElapsedTime();
    }

    void ButtonPress() => PressAmount++;
}
