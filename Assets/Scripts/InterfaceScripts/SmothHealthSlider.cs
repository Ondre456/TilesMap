using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmothHealthSlider : MonoBehaviour
{
    [SerializeField] private DamageAcceptor _damageAcceptor;

    private Slider _slider;
    private float _newHpValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _damageAcceptor.OnHealthChanged += TargetHpChanged;
        _slider.maxValue = _damageAcceptor.GetMaxHealth();
        _slider.value = _slider.maxValue;
        _newHpValue = _damageAcceptor.GetMaxHealth();
    }

    private void OnDisable()
    {
        _damageAcceptor.OnHealthChanged -= TargetHpChanged;
    }

    private void FixedUpdate()
    {
        const float Delta = 0.2f;

        _slider.value = Mathf.MoveTowards(_slider.value, _newHpValue, Delta);
    }

    private void TargetHpChanged()
    {
        _newHpValue = _damageAcceptor.Health;
    }
}
