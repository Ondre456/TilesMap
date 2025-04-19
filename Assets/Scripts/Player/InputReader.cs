using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string Horizontal = nameof(Horizontal);
    private const string Fire1 = nameof(Fire1);

    public event Action<float, bool> MovingInputOccurred;
    public event Action JumpOccurred;
    public event Action<float> AttackOccurred;

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
        MovingInputOccurred?.Invoke(direction, isWalking);
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown(Jump))
        {
            JumpOccurred?.Invoke();
        }
    }

    private void HandleAttackInput()
    {
        if (Input.GetButtonDown(Fire1))
        {
            float direction = Input.GetAxis(Horizontal);
            AttackOccurred?.Invoke(direction);
        }
    }
}