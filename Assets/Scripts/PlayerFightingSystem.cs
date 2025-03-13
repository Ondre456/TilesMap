using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFightingSystem : MonoBehaviour
{
    [SerializeField] private float _attackDelay = 0.8f;
    [SerializeField] private float _attackCooldown = 0.5f;
    [SerializeField] private float _attackMoveDistance = 1f;
    [SerializeField] private float _attackMoveSpeed = 10f;

    private bool _isAtack = false;
    private bool _canAtack = true;
    private WaitForSeconds _atackWait;
    private WaitForSeconds _atackCooldownWait;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _atackWait = new WaitForSeconds(_attackDelay);
        _atackCooldownWait = new WaitForSeconds(_attackCooldown);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Atack(float splashHorizontalComponent)
    {
        if (_canAtack == false)
            return;

        Vector2 splashDirection = new Vector2(splashHorizontalComponent, 0);
        StartCoroutine(AtackCourutine(splashDirection));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_isAtack)
            {
                Destroy(enemy.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator AtackCourutine(Vector2 attackDirection)
    {
        _isAtack = true;
        _rigidbody2D.velocity = attackDirection * _attackMoveSpeed;
        
        yield return _atackWait;

        _isAtack = false;
        StartCoroutine(AttackCooldownCourutine());
    }

    private IEnumerator AttackCooldownCourutine()
    {
        _canAtack = false;

        yield return _atackCooldownWait;

        _canAtack = true;
    }
}
