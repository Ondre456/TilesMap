using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private const int EnemyBaseSpeed = 1;
    private const string Attack = nameof(Attack);
    private const string Hit = nameof(Hit);

    public readonly int Speed = Animator.StringToHash(nameof(Speed));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        SetupSpeed();
    }

    public void SetupSpeed(float speed = EnemyBaseSpeed)
    {
        _animator.SetFloat(Speed, speed);
    }

    public void SetupAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void SetupHit()
    {
        _animator.SetTrigger(Hit);
    }
}
