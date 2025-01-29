using UnityEngine;
using UnityEngine.UI;

public class CounterEvents : MonoBehaviour
{
    [SerializeField] private Button _button;
    public float PressAmount;

    [SerializeField] private Timer _timer;
    public float ElapsedTime;

    private void Update()
    {
        ElapsedTime = _timer.GetElapsedTime();
    }

    public void ButtonPress() => PressAmount++;
}
