using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmothHealthSlider : HealthIndicator
{
    private Slider _slider;
    private float _newHpValue;
    private Coroutine _coroutine;

    private void Awake()
    {
        base.Awake();
        _slider = GetComponent<Slider>();
        _slider.maxValue = Target.MaxHealth;
        _slider.value = _slider.maxValue;
        _newHpValue = Target.MaxHealth;
    }

    protected override void TargetHealthChannged()
    {
        _newHpValue = Target.Value;
        
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothSlider());
    }

    private IEnumerator SmoothSlider()
    {
        const float Delta = 0.1f;
       
        while (Mathf.Abs(_slider.value - _newHpValue) > 0.01f)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _newHpValue, Delta);
            
            yield return null;
        }

        _slider.value = _newHpValue;
    }
}
