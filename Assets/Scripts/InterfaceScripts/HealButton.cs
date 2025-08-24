public class HealthButton : DamageAcceptorInterractButton
{
    protected override void OnClick()
    {
        Target.AcceptHeal(Value);
    }
}
