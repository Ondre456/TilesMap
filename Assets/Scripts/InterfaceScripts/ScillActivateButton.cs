using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ScillActivateButton : MonoBehaviour
{
    [SerializeField] private Skill _skill;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ActivateSkill);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ActivateSkill);
    }

    public void ActivateSkill()
    {
        if (_skill.CanBeActivated)
            _skill.Activate();
    }
}
