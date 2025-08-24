using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmothHealthSlider : HpIndicator
{
    private Slider _slider;
    private float _newHpValue;

    private void Awake()
    {
        base.Awake();
        _slider = GetComponent<Slider>();
        _slider.maxValue = DamageAcceptor.MaxHealth;
        _slider.value = _slider.maxValue;
        _newHpValue = DamageAcceptor.MaxHealth;
    }

    private void FixedUpdate()
    {
        const float Delta = 0.2f;

        _slider.value = Mathf.MoveTowards(_slider.value, _newHpValue, Delta);
    }

    protected override void TargetHpChannged()
    {
        _newHpValue = DamageAcceptor.Health;
    }
}
