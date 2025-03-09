using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorData : MonoBehaviour
{
    private const int BaseSpeed = 0;

    private Animator _animator;

    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetupParametres(float speed = BaseSpeed)
    {
        _animator.SetFloat(Params.Speed, speed);
    }
}
