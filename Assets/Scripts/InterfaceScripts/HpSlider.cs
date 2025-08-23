using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HpSlider : MonoBehaviour
{
    [SerializeField] private DamageAcceptor _damageAcceptor;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _damageAcceptor.OnHealthChanged += TargetHpChanged;
        _slider.maxValue = _damageAcceptor.GetMaxHealth();
        _slider.value = _slider.maxValue;
    }

    private void OnDisable()
    {
        _damageAcceptor.OnHealthChanged -= TargetHpChanged;
    }

    private void TargetHpChanged()
    {
        _slider.value = _damageAcceptor.Health;
    }
}
