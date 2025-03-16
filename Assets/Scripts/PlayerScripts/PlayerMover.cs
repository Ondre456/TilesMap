using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Flipper))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _acceleration = 2f;
    [SerializeField] private float _maxSpeed = 12f;
    [SerializeField] private float _deceleration = 4f;
    [SerializeField] private float _walkSpeed = 4f;

    private Rigidbody2D _rigidbody;
    private Flipper _movementDirectionChanger;
    private float _speed = 0;
    private float _currentMaxSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movementDirectionChanger = GetComponent<Flipper>();
    }

    public void Move(float horizontalComponent, bool isWalking)
    {
        const float VeryLittleNumber = 0.01f;

        if (isWalking)
            _currentMaxSpeed = _walkSpeed;
        else
            _currentMaxSpeed = _maxSpeed;

        if (Mathf.Abs(horizontalComponent) > VeryLittleNumber)
        {
            _speed += _acceleration * horizontalComponent;
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

        _movementDirectionChanger.SetDirection(_speed);

        Vector2 velocity = _rigidbody.velocity;
        velocity.x = _speed;
        _rigidbody.velocity = velocity;
    }

    public float GetSpeedCoefficient()
    {
        const float Threshhold = 0.5f;
        const float Rounding = 10f;

        float result = 0f;

        if (Mathf.Abs(_speed) <= _walkSpeed)
        {
            result = Mathf.Abs(_speed) / _walkSpeed * Threshhold;
        }
        else
        {
            result = Threshhold + ((Mathf.Abs(_speed) - _walkSpeed) / (_maxSpeed - _walkSpeed) * Threshhold);
        }

        result = Mathf.Round(result * Rounding) / Rounding;

        return result;
    }
}
