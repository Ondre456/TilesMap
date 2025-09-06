using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillAction))]
public class Skill : MonoBehaviour
{
    [SerializeField] private float _timeOfActive;
    [SerializeField] private float _timeOfCooldown;
    
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
        StartCoroutine(ActivateZone());
    }

    private IEnumerator<WaitForSeconds> ActivateZone()
    {
        CanBeActivated = false;
        _skillAction.enabled = true;

        yield return _skillTimer;

        _skillAction.enabled = false;
        StartCoroutine(Cooldown());
    }

    private IEnumerator<WaitForSeconds> Cooldown()
    {
        yield return _cooldownTimer;

        CanBeActivated = true;
    }
}
