using UnityEngine;

[RequireComponent(typeof(Patrool))]
[RequireComponent(typeof(Pursuer))]
[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : MonoBehaviour
{
    private Patrool _patrool;
    private Pursuer _pursuer;

    private void Awake()
    {
        _patrool = GetComponent<Patrool>();
        _pursuer = GetComponent<Pursuer>();
    }

    private void FixedUpdate()
    {
        if (_pursuer.IsPurse)
            _pursuer.Purse();
        else
            _patrool.Move();
    }
}
