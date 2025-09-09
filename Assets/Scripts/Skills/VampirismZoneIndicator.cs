using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SkillZoneIndicator : SkillIndicator
{
    private SpriteRenderer _actionZone;

    private void Awake()
    {
        _actionZone = GetComponent<SpriteRenderer>();
    }

    public override void MakeInvisible()
    {
        SetIndicatorAlpha(0.0f);
    }

    public override void MakeVisible()
    {
        SetIndicatorAlpha(0.3f);
    }

    private void SetIndicatorAlpha(float alpha)
    {
        Color color = _actionZone.color;
        color.a = Mathf.Clamp01(alpha);
        _actionZone.color = color;
    }
}
