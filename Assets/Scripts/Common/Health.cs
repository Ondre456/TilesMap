using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    
    public float MaxHealth { get => _maxHealth; }
    public float Value {  get; private set; }
    public bool IsAlive => Value > 0;

    public event Action OnChanged;

    private void Awake()
    {
        Value = _maxHealth;
    }

    public void AcceptDamage(float damage)
    {
        if (Value - damage < 0)
            Value = 0;

        Value -= damage;

        OnChanged?.Invoke();

        if (IsAlive == false)
            Destroy(gameObject);
    }

    public void AcceptHeal(float heal)
    {
        if (Value <= 0 || Value == _maxHealth)
            return;

        Value += heal;

        if (Value > MaxHealth)
            Value = MaxHealth;

        OnChanged?.Invoke();
    }
}
