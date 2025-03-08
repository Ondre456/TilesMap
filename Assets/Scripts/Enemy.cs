using UnityEngine;

[RequireComponent(typeof(Patrool))]
[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : MonoBehaviour
{
    private void Awake()
    {
        EnemyAnimator enemyAnimator = GetComponent<EnemyAnimator>();
        enemyAnimator.SetupSpeed();
    }
}
