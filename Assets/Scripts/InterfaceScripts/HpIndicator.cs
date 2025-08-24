using UnityEngine;

public abstract class HpIndicator : MonoBehaviour
{
    [SerializeField] protected HealthyObject DamageAcceptor;

    protected void Awake()
    {
        DamageAcceptor.OnHealthChanged += TargetHpChannged;
    }

    private void OnDestroy()
    {
        DamageAcceptor.OnHealthChanged -= TargetHpChannged;
    }

    protected abstract void TargetHpChannged();
}
