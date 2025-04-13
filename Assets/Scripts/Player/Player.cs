using UnityEngine;

[RequireComponent(typeof(PlayerAnimatorData))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(CoinCollector))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerFightingSystem))]
[RequireComponent(typeof(DamageAcceptor))]
public class Player : MonoBehaviour
{
    private PlayerAnimatorData _playerAnimatorData;
    private PlayerMover _playerMover;
    private Jumper _jumper;
    private InputReader _inputReader;
    private PlayerFightingSystem _playerFightingSystem;
    private DamageAcceptor _damageAcceptor;
    private bool _isAttack;
    private bool _isMove;
    private bool _isWalking;
    private bool _isJump;
    private bool _isHited;
    private float _direction;

    private void Awake()
    {
        _playerAnimatorData = GetComponent<PlayerAnimatorData>();
        _playerMover = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
        _inputReader = GetComponent<InputReader>();
        _playerFightingSystem = GetComponent<PlayerFightingSystem>();
        _damageAcceptor = GetComponent<DamageAcceptor>();

        _inputReader.OnMovingInput += OnMove;
        _inputReader.OnJump += Jump;
        _inputReader.OnAttack += HandleAttack;
    }

    private void FixedUpdate()
    {
        if (_isAttack)
        {
            _playerFightingSystem.Splash();
            _isAttack = _playerFightingSystem.IsAttack;
        }
        else
        {
            _playerMover.Move(_direction, _isWalking);
        }

        _playerAnimatorData.SetupParametres(_playerMover.GetSpeedCoefficient(), _isAttack);
    }

    private void OnMove(float direction, bool isWalking)
    {

        _isWalking = isWalking;
        _direction = direction;
    }

    private void HandleAttack(float direction)
    {
        _isAttack = true;
        _playerFightingSystem.Atack(direction);
        _playerAnimatorData.SetupParametres(_playerMover.GetSpeedCoefficient(), true);
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
