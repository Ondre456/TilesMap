using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string Horizontal = nameof(Horizontal);

    private bool _isJump;

    public float Direction { get; private set; }
    public bool IsWalking { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetButton(Jump))
            _isJump = true;

        IsWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;

        return localValue;
    }
}
