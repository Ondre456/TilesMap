using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(DamageAcceptor))]
public class PlayerFightingSystem : MonoBehaviour
{
    [SerializeField] private float _attackMoveSpeed = 10f;
    [SerializeField] private int _damage = 1;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _attackDirection;
    private Fighter _fighter;

    public DamageAcceptor DamageAcceptor { get; private set; }
    
    private void Awake()
    {
        DamageAcceptor = GetComponent<DamageAcceptor>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _fighter = GetComponent<Fighter>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_fighter.IsAttack)
            {
                enemy.DamageAcceptor.AcceptDamage(_damage, this.transform.position);
            }
        }
    }

    public void Splash(float direction)
    {
        var velocity = _rigidbody2D.velocity;
        velocity.x = direction * _attackMoveSpeed;
        _rigidbody2D.velocity = velocity;
    }
}
