using UnityEngine;

[RequireComponent(typeof(PlayerAnimatorData))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(CoinCollector))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(InputReader))]
public class Player : MonoBehaviour
{
    private PlayerAnimatorData _playerAnimatorData;
    private PlayerMover _playerMover;
    private Jumper _jumper;
    private InputReader _inputReader;

    private void Awake()
    {
        _playerAnimatorData = GetComponent<PlayerAnimatorData>();
        _playerMover = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        _playerMover.Move(_inputReader.Direction, _inputReader.IsWalking);

        if (_inputReader.GetIsJump())
            _jumper.TryJump();

        _playerAnimatorData.SetupParametres(_playerMover.GetSpeedCoefficient());

    }
}
