using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private FloatVariable _health;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField] private GameObject _deathCanvas;

    private void Start()
    {
        if (_health)
        {
            slider.maxValue = 1000f;
            slider.value = _health.Value;
            gradient.Evaluate(1f);
        }
    }

    public void UpdateBar()
    {
        slider.value = _health.Value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if(_health.Value<=0)
            _deathCanvas.SetActive(true);
    }
}
