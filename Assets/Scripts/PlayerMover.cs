using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MovementDirectionChanger))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _acceleration = 2f;
    [SerializeField] private float _maxSpeed = 12f;
    [SerializeField] private float _deceleration = 4f;
    [SerializeField] private float _walkSpeed = 4f;
    [SerializeField] private float _movementBlockDuration = 0.1f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private MovementDirectionChanger _movementDirectionChanger;
    private float _speed = 0;
    private float _currentMaxSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _movementDirectionChanger = GetComponent<MovementDirectionChanger>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            _currentMaxSpeed = _walkSpeed;
        else
            _currentMaxSpeed = _maxSpeed;

        _movementDirectionChanger.SetDirection(_speed);

        if (Mathf.Abs(x) > 0.01f)
        {
            _speed += _acceleration * x;
            _speed = Mathf.Clamp(_speed, -_currentMaxSpeed, _currentMaxSpeed);
        }
        else
        {
            if (_speed > 0)
            {
                _speed -= _deceleration;
                
                if (_speed < 0)
                    _speed = 0;
            }
            else if (_speed < 0)
            {
                _speed += _deceleration;
                
                if (_speed > 0)
                    _speed = 0;
            }
        }

        Vector2 velocity = _rigidbody.velocity;
        velocity.x = _speed;
        _rigidbody.velocity = velocity;
        UpdateMovementAnimation();
    }

    private void UpdateMovementAnimation()
    {
        const float AnimationThreshhold = 0.5f;

        float animationBlend = 0f;

        if (Mathf.Abs(_speed) <= _walkSpeed)
        {
            animationBlend = Mathf.Abs(_speed) / _walkSpeed * AnimationThreshhold;
        }
        else
        {
            animationBlend = AnimationThreshhold + ((Mathf.Abs(_speed) - _walkSpeed) / (_maxSpeed - _walkSpeed) * AnimationThreshhold);
        }

        _animator.SetFloat("Speed", animationBlend);
    }
}
