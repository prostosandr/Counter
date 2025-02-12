using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textCounter;

    private void OnEnable()
    {
        _counter.Changed += ChangedNumber;
    }

    private void OnDisable()
    {
        _counter.Changed -= ChangedNumber;
    }

    private void ChangedNumber(float currentNumber)
    {
        DisplayNumber(currentNumber);
    }

    private void DisplayNumber(float number)
    {
        _textCounter.text = number.ToString("");
    }
}
