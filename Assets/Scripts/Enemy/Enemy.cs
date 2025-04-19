using UnityEngine;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(Pursuer))]
[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(DamageAcceptor))]
[RequireComponent(typeof(Fighter))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private Patrol _patrool;
    private Pursuer _pursuer;
    private EnemyAnimator _enemyAnimator;
    private Fighter _fighter;

    public DamageAcceptor DamageAcceptor { get; private set; }

    private void Awake()
    {
        _patrool = GetComponent<Patrol>();
        _pursuer = GetComponent<Pursuer>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
        DamageAcceptor = GetComponent<DamageAcceptor>();
        _fighter = GetComponent<Fighter>();
        _pursuer.EnterAttackZone += _fighter.Attack;
        _pursuer.EnterAttackZone += SetAttackAnimation;
    }

    private void FixedUpdate()
    {
        if (DamageAcceptor.IsHited)
            DamageAcceptor.HitMove();
        else if (_pursuer.IsPurse)
            _pursuer.Purse();
        else
            _patrool.Move();
    }

    private void SetAttackAnimation()
    {
        if (_fighter.IsAttack)
        {
            _enemyAnimator.SetupAttack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerFightingSystem opponent))
        {
            if (_fighter.IsAttack)
            {
                opponent.DamageAcceptor.AcceptDamage(_damage, this.transform.position);
            }
        }
    }
}
