using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorData : MonoBehaviour
{
    private const int BaseSpeed = 0;
    private const bool DefaultAtackingState = false;
    private Animator _animator;

    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public const string Attack = nameof(Attack);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetupParametres(float speed = BaseSpeed, bool isAtack = DefaultAtackingState)
    {
        _animator.SetFloat(Params.Speed, speed);

        if (isAtack)
            _animator.SetTrigger(Params.Attack);
    }
}
