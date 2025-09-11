using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class VampirismAction : SkillAction
{
    [SerializeField] private float _damage;
    [SerializeField] private Health _health;

    private CapsuleCollider2D _collider;
    private List<TargetInfo> _targets;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _collider.isTrigger = true;
        _targets = new List<TargetInfo>();
    }

    private void FixedUpdate()
    {
        if (_targets.Count == 0) return;

        TargetInfo closestTarget = null;
        float minDistanceSqr = float.MaxValue;
        Vector3 currentPosition = transform.position;

        foreach (var target in _targets)
        {
            float distanceSqr = (target.Position - currentPosition).sqrMagnitude;

            if (distanceSqr < minDistanceSqr)
            {
                minDistanceSqr = distanceSqr;
                closestTarget = target;
            }
        }

        if (closestTarget != null)
        {
            closestTarget.TargetHealth.AcceptDamage(_damage);
            _health.AcceptHeal(_damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health opponentHealth;

        if (collision.TryGetComponent(out opponentHealth))
        {
            TargetInfo targetInfo = new TargetInfo(
                collision.transform,
                opponentHealth,
                collision.transform.position
            );

            _targets.Add(targetInfo);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TargetInfo targetToRemove = _targets.Find(t => t.TargetTransform == collision.transform);

        if (targetToRemove != null)
        {
            _targets.Remove(targetToRemove);
        }
    }
}
