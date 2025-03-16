using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PurseZone : MonoBehaviour
{
    [SerializeField] private Pursuer _purser;

    private BoxCollider2D _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _boxCollider.isTrigger = true;
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
