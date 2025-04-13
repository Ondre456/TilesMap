using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string Horizontal = nameof(Horizontal);
    private const string Fire1 = nameof(Fire1);
    private const float MovingStopMeaning = 0;

    private float _currentDirection;
    private bool _isMoving;
    private bool _isWalking;

    public event Action<float, bool> OnMovingInput;
    public event Action OnJump;
    public event Action<float> OnAttack;
    public event Action OnStopMoving;
    public event Action<bool> OnWalkStateChanged;

    private void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleAttackInput();
    }

    private void HandleMovementInput()
    {
        float direction = Input.GetAxis(Horizontal);
        bool isWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (direction != MovingStopMeaning && !_isMoving)
        {
            _isMoving = true;
            _currentDirection = direction;
            OnMovingInput?.Invoke(direction, isWalking);
            UpdateWalkState(isWalking);
        }
        else if (direction != MovingStopMeaning && _isMoving && direction != _currentDirection)
        {
            _isMoving = true;
            _currentDirection = direction;
            OnMovingInput?.Invoke(direction, isWalking);
            UpdateWalkState(isWalking);
        }
        else if (direction == MovingStopMeaning && _isMoving)
        {
            _isMoving = false;
            OnMovingInput(direction, isWalking);
        }

        if (_isMoving)
        {
            UpdateWalkState(isWalking);
        }

        if (_isMoving && direction == MovingStopMeaning)
        {
            _isMoving = false;
            OnStopMoving?.Invoke();
        }

    }

    private void UpdateWalkState(bool newWalkState)
    {
        if (_isWalking != newWalkState)
        {
            _isWalking = newWalkState;
            OnWalkStateChanged?.Invoke(_isWalking);
        }
    }

    private void HandleJumpInput()
    {
        bool isJump = Input.GetButtonDown(Jump);

        if (isJump)
        {
            OnJump?.Invoke();
        }
    }

    private void HandleAttackInput()
    {
        bool isAttack = Input.GetButtonDown(Fire1);

        if (isAttack)
        {
            OnAttack?.Invoke(_currentDirection);
        }
    }
}
