using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class DamageAcceptorInterractButton : MonoBehaviour
{
    [SerializeField] protected int Value;
    [SerializeField] protected HealthyObject Target;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    protected abstract void OnClick();
}
