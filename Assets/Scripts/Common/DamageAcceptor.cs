using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DamageAcceptor : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;

    private Vector2 _opponentPosition;

    public int Health { get; private set; }

    private void Awake()
    {
        Health = _maxHealth;
    }

    public void AcceptDamage()
    {
        Health--;

        if (Health == 0)
            Destroy(gameObject);
    }
}
