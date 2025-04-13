using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(DamageAcceptor))]
public class PlayerFightingSystem : MonoBehaviour
{
    [SerializeField] private float _attackDelay = 0.8f;
    [SerializeField] private float _attackCooldown = 0.5f;
    [SerializeField] private float _attackMoveSpeed = 10f;
    [SerializeField] private SpawnPoint _spawn;

    private bool _canAttack = true;
    private WaitForSeconds _attackWait;
    private WaitForSeconds _attackCooldownWait;
    private Rigidbody2D _rigidbody2D;
    private DamageAcceptor _damageAcceptor;
    private Vector2 _attackDirection;

    public bool IsAttack { get; private set; }

    private void Awake()
    {
        _damageAcceptor = GetComponent<DamageAcceptor>();
        _attackWait = new WaitForSeconds(_attackDelay);
        _attackCooldownWait = new WaitForSeconds(_attackCooldown);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (IsAttack == false)
            {
                _damageAcceptor.AcceptDamage();

                transform.position = _spawn.transform.position;
            }
        }
    }

    public void Atack(float splashHorizontalComponent)
    {
        if (_canAttack == false)
            return;

        _attackDirection = new Vector2(splashHorizontalComponent, _rigidbody2D.velocity.y);
        StartCoroutine(AtackCoroutine());
    }

    public void Splash()
    {
        _rigidbody2D.velocity = new Vector2(_attackDirection.x * _attackMoveSpeed, _attackDirection.y) ;
    }

    private IEnumerator AtackCoroutine()
    {
        _canAttack = false;
        IsAttack = true;

        yield return _attackWait;

        IsAttack = false;

        yield return AttackCooldownCoroutine();
    }

    private IEnumerator AttackCooldownCoroutine()
    {
        yield return _attackCooldownWait;

        _canAttack = true;
    }
}
