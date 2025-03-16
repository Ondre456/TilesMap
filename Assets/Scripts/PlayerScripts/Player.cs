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

        _inputReader.OnMovingInput += OnMove;
        _inputReader.OnStop += Stop;
        _inputReader.OnJump += Jump;
        _inputReader.OnAttack += Attack;
    }

    private void OnMove(float direction, bool isWalking)
    {
        _playerMover.Move(direction, isWalking);
        _playerAnimatorData.SetupParametres(_playerMover.GetSpeedCoefficient());
    }

    private void Attack(float direction)
    {
        _playerFightingSystem.Atack(direction);
    }

    private void Jump()
    {
        _jumper.TryJump();
    }

    private void Stop()
    {
        _playerAnimatorData.SetupParametres();
    }

}
