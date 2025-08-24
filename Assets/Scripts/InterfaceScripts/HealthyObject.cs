using System;
using UnityEngine;

public class HealthyObject : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    
    public int MaxHealth { get => _maxHealth; }
    public int Health {  get; private set; }
    public bool IsAlive { get => Health > 0; }

    public event Action OnHealthChanged;

    private void Awake()
    {
        Health = _maxHealth;
    }

    public void AcceptDamage(int damage)
    {
        Health -= damage;

        OnHealthChanged?.Invoke();

        if (IsAlive == false)
            Destroy(gameObject);
    }

    public void AcceptHeal(int heal)
    {
        if (Health <= 0 || Health == _maxHealth)
            return;

        Health += heal;
        OnHealthChanged?.Invoke();
    }
}
