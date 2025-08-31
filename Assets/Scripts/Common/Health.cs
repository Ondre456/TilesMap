using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    
    public int MaxHealth { get => _maxHealth; }
    public int Value {  get; private set; }
    public bool IsAlive => Value > 0;

    public event Action OnChanged;

    private void Awake()
    {
        Value = _maxHealth;
    }

    public void AcceptDamage(int damage)
    {
        Value -= damage;

        OnChanged?.Invoke();

        if (IsAlive == false)
            Destroy(gameObject);
    }

    public void AcceptHeal(int heal)
    {
        if (Value <= 0 || Value == _maxHealth)
            return;

        Value += heal;

        if (Value > MaxHealth)
            Value = MaxHealth;

        OnChanged?.Invoke();
    }
}
