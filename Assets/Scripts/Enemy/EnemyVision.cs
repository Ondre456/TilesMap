using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Pursuer))]
public class EnemyVision : MonoBehaviour
{
    private Pursuer _purser;
    private BoxCollider2D _boxCollider;

    private void Awake()
    {
        _purser = GetComponent<Pursuer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _purser.AcceptGoal(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _purser.LooseGoal();
        }
    }
}
