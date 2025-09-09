using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillAction))]
public class Skill : MonoBehaviour
{
    [SerializeField] private float _timeOfActive;
    [SerializeField] private float _timeOfCooldown;
    [SerializeField] private List<SkillIndicator> _indicators;

    private WaitForSeconds _cooldownTimer;
    private WaitForSeconds _skillTimer;
    private SkillAction _skillAction;

    public bool CanBeActivated { get; protected set; }

    private void Awake()
    {
        CanBeActivated = true;
        _skillAction = GetComponent<SkillAction>();
        _skillAction.enabled = false;
        _cooldownTimer = new WaitForSeconds(_timeOfCooldown);
        _skillTimer = new WaitForSeconds(_timeOfActive);
    }

    public void Activate()
    {
        if (CanBeActivated)
            StartCoroutine(Active());
    }

    private IEnumerator Active()
    {
        CanBeActivated = false;
        _skillAction.enabled = true;
        
        foreach (var indicator in _indicators)
            indicator.MakeVisible();

        yield return _skillTimer;

        foreach (var indicator in _indicators)
            indicator.MakeInvisible();

        _skillAction.enabled = false;
        yield return Cooldown();
    }

    private IEnumerator Cooldown()
    {
        yield return _cooldownTimer;

        CanBeActivated = true;
    }
}
