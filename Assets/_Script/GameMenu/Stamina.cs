using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stamina : MonoBehaviour
{
    public static Stamina Instance { get; private set; }

    public Slider _slider;

    public int _maxStamina;
    public int _staminaRegen;
    public int _staminaUse;
    public GameObject staminaText;

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
            _slider.value += _staminaRegen * Time.deltaTime;
        }

        // Show remaining stamina.
        var _staminText = staminaText.GetComponent<TextMeshProUGUI>();
        _staminText.text = Mathf.RoundToInt(CurrentStamina()).ToString();
    }

    public void UsingStamina(int value)
    {
        _slider.value -= value;
    }

    public float CurrentStamina()
    {
        var currentStamina = _slider.value;
        return currentStamina;
    }

}
