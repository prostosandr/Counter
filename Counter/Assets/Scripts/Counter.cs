using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _currentNumber;
    [SerializeField] private Coroutine _coroutine;

    [SerializeField] private bool _isCounting;

    public event Action<float> Changed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }
            }
            else
            {
                _coroutine = StartCoroutine(CountUp());
            }

            _isCounting = !_isCounting;
        }
    }

    private void IncreaseNumber()
    {
        _currentNumber++;

        Changed?.Invoke(_currentNumber);
    }

    private IEnumerator CountUp()
    {
        float delay = 0.5f;
        var wailt = new WaitForSeconds(delay);
        bool enabled = true;

        while (enabled)
        {
            IncreaseNumber();

            yield return wailt;
        }
    }
}
