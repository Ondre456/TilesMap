using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HpSlider : HpIndicator
{
    private Slider _slider;

    private void Awake()
    {
        base.Awake();
        _slider = GetComponent<Slider>();
        _slider.maxValue = DamageAcceptor.MaxHealth;
        _slider.value = _slider.maxValue;
    }

    protected override void TargetHpChannged()
    {
        _slider.value = DamageAcceptor.Health;
    }

}
