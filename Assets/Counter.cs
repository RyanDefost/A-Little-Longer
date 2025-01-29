using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private Slider _slider;
    private float _sliderValue = 0;
    private float _IncreaseAmount = 10;

    private CounterEvents _events;

    private bool _isHolding = false;
    private bool _isPressing;

    private void Start()
    {
        _events = gameObject.GetComponent<CounterEvents>();

        StartCoroutine(CountDown(0.01f, 1f));
    }

    private void Update()
    {
        if (_slider.value <= 0)
            _endScreen.SetActive(true);

        if (_isHolding)
            TryAddCount(0.05f);
    }

    private IEnumerator CountDown(float amount, float time)
    {
        while (_slider.value <= 1)
        {
            if (_events.PressAmount > _IncreaseAmount)
            {
                amount += 0.01f;
                _IncreaseAmount += 10;
            }

            _slider.value -= amount;

            yield return new WaitForSeconds(time);
        }
    }

    public void TryAddCount(float amount)
    {
        if (_isPressing == true)
            return;

        StartCoroutine(AddCounter(amount, 0.5f));
    }

    public IEnumerator AddCounter(float amount, float time)
    {
        _isPressing = true;

        _events.ButtonPress();

        _slider.value += amount;
        yield return new WaitForSeconds(time);

        _isPressing = false;
    }

    public void StartHold() => _isHolding = true;
    public void StopHold() => _isHolding = false;
}
