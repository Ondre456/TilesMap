using UnityEngine;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(Pursuer))]
[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : MonoBehaviour
{
    private Patrol _patrool;
    private Pursuer _pursuer;
    private EnemyAnimator _enemyAnimator;

    private void Awake()
    {
        _patrool = GetComponent<Patrol>();
        _pursuer = GetComponent<Pursuer>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
        _pursuer.EnterAttackZone += Attack;
    }

    private void FixedUpdate()
    {
        if (_pursuer.IsPurse)
            _pursuer.Purse();
        else
            _patrool.Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerFightingSystem opponent))
        {
            if (opponent.IsAttack == false)
            {
                Destroy(opponent.gameObject);
            }
        }
    }

    private void Attack()
    {
        _enemyAnimator.SetupAttack();
    }
}
