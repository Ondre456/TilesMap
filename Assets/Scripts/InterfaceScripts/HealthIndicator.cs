using UnityEngine;

public abstract class HealthIndicator : MonoBehaviour
{
    [SerializeField] protected Health Target;

    protected void Awake()
    {
        Target.OnChanged += TargetHealthChannged;
    }

    private void OnDestroy()
    {
        Target.OnChanged -= TargetHealthChannged;
    }

    protected abstract void TargetHealthChannged();
}
