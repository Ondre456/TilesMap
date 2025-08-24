using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthyObject))]
public class DamageAcceptor : MonoBehaviour
{
    [SerializeField] private int _hitFrames = 20;
    [SerializeField] private float _moveSpeed = 20f;

    private Vector2 _opponentPosition;
    private Rigidbody2D _rigidbody;
    private int _framesSinceHit;
    private HealthyObject _health;

    public bool IsHited { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<HealthyObject>();
    }

    public void AcceptDamage(int damage, Vector2 opponentPosition = default)
    {
        _health.AcceptDamage(damage);
        IsHited = true;
        _opponentPosition = opponentPosition;
    }

    public void HitMove()
    {
        if (IsHited)
        {
            _framesSinceHit++;

            Vector2 direction = (Vector2)transform.position - _opponentPosition;
            direction.Normalize();

            _rigidbody.MovePosition(_rigidbody.position + direction * _moveSpeed * Time.deltaTime);

            if (_framesSinceHit >= _hitFrames)
            {
                IsHited = false;
                _framesSinceHit = 0;
            }
        }
    }
}
