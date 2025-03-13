using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string Horizontal = nameof(Horizontal);
    private const string Fire1 = nameof(Fire1);

    private bool _isJump;
    private bool _isAtack;

    public bool IsJump
    {
        get
        {
            bool temporal = _isJump;
            _isJump = false;

            return temporal;
        }
    }

    public bool IsAtack
    {
        get
        {
            bool temporal = _isAtack;
            _isAtack = false;

            return temporal;
        }
    }

    public float Direction { get; private set; }
    public bool IsWalking { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);
        _isJump = Input.GetButtonDown(Jump);
        _isAtack = Input.GetButtonDown(Fire1);
        IsWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }
}
