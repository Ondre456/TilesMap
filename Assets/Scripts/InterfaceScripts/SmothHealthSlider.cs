using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmothHealthSlider : HealthIndicator
{
    private Slider _slider;
    private Coroutine _coroutine;

    private void Awake()
    {
        base.Awake();
        _slider = GetComponent<Slider>();
        _slider.interactable = false;
        _slider.maxValue = Target.MaxHealth;
        _slider.value = _slider.maxValue;
    }

    protected override void TargetHealthChannged()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothSlider());
    }

    private IEnumerator SmoothSlider()
    {
        const float Delta = 0.1f;
       
        while (Mathf.Abs(_slider.value - Target.Value) > 0.01f)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, Target.Value, Delta);
            
            yield return null;
        }

        _slider.value = Target.Value;
    }
}
