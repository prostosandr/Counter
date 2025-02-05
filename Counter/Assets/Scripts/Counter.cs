using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _currentNumber;

    [SerializeField] private bool _isCounting;

    [SerializeField] private TextMeshProUGUI _counterText;

    private void Start()
    {
        _currentNumber = PlayerPrefs.GetFloat("CounterValue", 0);
        DisplayCount();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
                StopCoroutine("Count");
            else
                StartCoroutine("Count");

            _isCounting = !_isCounting;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("CounterValue", _currentNumber);
        PlayerPrefs.Save();
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(0.5f);

        while (true)
        {
            _currentNumber++;
            DisplayCount();
            yield return wait;
        }
    }

    private void DisplayCount()
    {
        _counterText.text = _currentNumber.ToString("");
    }
}
