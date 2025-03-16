using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string Horizontal = nameof(Horizontal);
    private const string Fire1 = nameof(Fire1);

    private float _oldDirection;
    private bool _isMove;

    public Action<float, bool> OnMovingInput;
    public Action OnJump;
    public Action<float> OnAttack;
    public Action OnStop;

    private void Update()
    {
        const float MovingStopMeaning = 0;

        float direction = Input.GetAxis(Horizontal);

        if (direction != MovingStopMeaning)
        {
            bool isWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            OnMovingInput?.Invoke(direction, isWalking);
            _isMove = true;
        }

        if (_isMove && direction == MovingStopMeaning)
        {
            OnStop?.Invoke();
            _isMove = false;
        }

        bool isJump = Input.GetButtonDown(Jump);

        if (isJump)
        {
            OnJump?.Invoke();
        }

        bool isAttack = Input.GetButtonDown(Fire1);

        if (isAttack)
        {
            OnAttack?.Invoke(direction);
        }
    }
}
