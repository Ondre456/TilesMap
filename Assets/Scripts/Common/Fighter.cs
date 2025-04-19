using System.Collections;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private float _attackDelay = 0.8f;
    [SerializeField] private float _attackCooldown = 2.0f;
    [SerializeField] private WaitForSeconds _waitForSeconds;
    [SerializeField] private LineRenderer _attackIndicator;

    private WaitForSeconds _attackWait;
    private WaitForSeconds _attackCooldownWait;
    private bool _canAttack = true;

    public bool IsAttack { get; set; }

    private void Awake()
    {
        _attackWait = new WaitForSeconds(_attackDelay);
        _attackCooldownWait = new WaitForSeconds(_attackCooldown);
    }

    public void Attack()
    {
        if (_canAttack == false)
            return;

        StartCoroutine(AtackCoroutine());
    }

    private IEnumerator AtackCoroutine()
    {
        _canAttack = false;
        IsAttack = true;
        ShowAttackIndicator(true);

        yield return _attackWait;

        IsAttack = false;
        ShowAttackIndicator(false);

        yield return AttackCooldownCoroutine();
    }

    private IEnumerator AttackCooldownCoroutine()
    {
        yield return _attackCooldownWait;

        _canAttack = true;
    }

    private void ShowAttackIndicator(bool state)
    {
        if (_attackIndicator != null)
        {
            _attackIndicator.enabled = state;

            if (state)
            {
                _attackIndicator.positionCount = 4;
                _attackIndicator.SetPosition(0, transform.position + new Vector3(-1f, 0f, 0f));
                _attackIndicator.SetPosition(1, transform.position + new Vector3(1f, 0f, 0f));
                _attackIndicator.SetPosition(2, transform.position + new Vector3(1f, 0f, 1f));
                _attackIndicator.SetPosition(3, transform.position + new Vector3(-1f, 0f, 1f));
                _attackIndicator.loop = true;
            }
        }
    }
}
