using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DamageAcceptor : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _hitFrames = 20;
    [SerializeField] private float _moveSpeed = 20f;

    private Vector2 _opponentPosition;
    private Rigidbody2D _rigidbody;
    private int _framesSinceHit;

    public int Health { get; private set; }
    public bool IsHited { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Health = _maxHealth;
    }

    public void AcceptDamage(int damage, Vector2 opponentPosition)
    {
        Health -= damage;
        IsHited = true;
        _opponentPosition = opponentPosition;

        if (Health == 0)
            Destroy(gameObject);
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
