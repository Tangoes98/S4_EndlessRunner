using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public static Stamina Instance { get; private set; }

    public Slider _slider;

    public int _maxStamina;
    public int _staminaRegen;
    public int _staminaUse;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _maxStamina = 100;
        _slider.value = _maxStamina;
    }

    private void Update()
    {
        if (_slider.value < _maxStamina)
        {
            _slider.value += _staminaRegen *  Time.deltaTime;
        }
    }

    public void UsingStamina(int value)
    {
        _slider.value -= value;
    }
}
