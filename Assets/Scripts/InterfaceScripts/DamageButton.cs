public class DamageButton : DamageAcceptorInterractButton
{
    protected override void OnClick()
    {
        Target.AcceptDamage(Value);
    }
}
