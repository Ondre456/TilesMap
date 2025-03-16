using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFightingSystem : MonoBehaviour
{
    [SerializeField] private float _attackDelay = 0.8f;
    [SerializeField] private float _attackCooldown = 0.5f;
    [SerializeField] private float _attackMoveSpeed = 10f;

    private bool _canAttack = true;
    private WaitForSeconds _attackWait;
    private WaitForSeconds _attackCooldownWait;
    private Rigidbody2D _rigidbody2D;

    public bool IsAttack { get; private set; }

    private void Awake()
    {
        _attackWait = new WaitForSeconds(_attackDelay);
        _attackCooldownWait = new WaitForSeconds(_attackCooldown);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Atack(float splashHorizontalComponent)
    {
        if (_canAttack == false)
            return;

        Vector2 splashDirection = new Vector2(splashHorizontalComponent, 0);
        StartCoroutine(AtackCoroutine(splashDirection));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (IsAttack)
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    private IEnumerator AtackCoroutine(Vector2 attackDirection)
    {
        IsAttack = true;
        _rigidbody2D.velocity = attackDirection * _attackMoveSpeed;
        
        yield return _attackWait;

        IsAttack = false;

        yield return AttackCooldownCoroutine();
    }

    private IEnumerator AttackCooldownCoroutine()
    {
        _canAttack = false;

        yield return _attackCooldownWait;

        _canAttack = true;
    }
}
