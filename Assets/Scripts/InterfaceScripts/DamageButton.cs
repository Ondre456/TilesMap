using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageButton : MonoBehaviour
{
    [SerializeField] private DamageAcceptor _target;
    
    private int _damage = 1;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        _target.AcceptDamage(_damage);
    }
}
