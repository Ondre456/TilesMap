using UnityEngine;

[RequireComponent(typeof(PlayerAnimatorData))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(CoinCollector))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerFightingSystem))]
public class Player : MonoBehaviour
{
    private PlayerAnimatorData _playerAnimatorData;
    private PlayerMover _playerMover;
    private Jumper _jumper;
    private InputReader _inputReader;
    private PlayerFightingSystem _playerFightingSystem;

    private void Awake()
    {
        _playerAnimatorData = GetComponent<PlayerAnimatorData>();
        _playerMover = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
        _inputReader = GetComponent<InputReader>();
        _playerFightingSystem = GetComponent<PlayerFightingSystem>();
    }

    private void Update()
    {
        bool isAtack = _inputReader.IsAtack;

        _playerAnimatorData.SetupParametres(_playerMover.GetSpeedCoefficient(), isAtack);

        if (_inputReader.IsJump)
            _jumper.TryJump();

        if (isAtack)
        {
            _playerFightingSystem.Atack(_inputReader.Direction);
        }
        else
        {
            _playerMover.Move(_inputReader.Direction, _inputReader.IsWalking);
        }
    }
}
