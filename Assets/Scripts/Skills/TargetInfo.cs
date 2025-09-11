using UnityEngine;

public class TargetInfo
{
    public TargetInfo(Transform targetTransform, Health health, Vector3 pos)
    {
        TargetTransform = targetTransform;
        TargetHealth = health;
        Position = pos;
    }

    public Transform TargetTransform { get; private set; }
    public Health TargetHealth { get; private set; }
    public Vector3 Position { get; private set; }
}