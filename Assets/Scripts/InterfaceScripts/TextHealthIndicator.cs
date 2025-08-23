using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthIndicator : MonoBehaviour
{
    [SerializeField] private DamageAcceptor _target;

    private TextMeshProUGUI _healthTextBox;
    private int _targetMaxHealth;

    private void Awake()
    {
        _healthTextBox = GetComponent<TextMeshProUGUI>();
        _target.OnHealthChanged += ChangeHpText;
        _targetMaxHealth = _target.GetMaxHealth();
        _healthTextBox.text = $"{_targetMaxHealth}/{_targetMaxHealth}";
    }

    private void OnDisable()
    {
        _target.OnHealthChanged -= ChangeHpText;
    }

    private void ChangeHpText()
    {
        _healthTextBox.text = $"{_target.Health}/{_targetMaxHealth}";
    }
}
