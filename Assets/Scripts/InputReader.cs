using UnityEngine;

[RequireComponent(typeof(PlayerAnimatorData))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(CoinCollector))]
[RequireComponent(typeof(Jumper))]
public class InputReader : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string Horizontal = nameof(Horizontal);

    private PlayerAnimatorData _playerAnimatorData;
    private PlayerMover _playerMover;
    private Jumper _jumper;

    private void Awake()
    {
        _playerAnimatorData = GetComponent<PlayerAnimatorData>();
        _playerMover = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButton(Jump))
            _jumper.TryJump();

        float horizontalMovementComponent = Input.GetAxis(Horizontal);
        bool isWalking = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        _playerMover.Move(horizontalMovementComponent, isWalking);
        _playerAnimatorData.SetupParametres(_playerMover.GetSpeedCoefficient());
    }
}
