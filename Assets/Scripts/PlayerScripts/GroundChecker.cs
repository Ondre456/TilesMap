using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    private Collider2D[] _colliders = new Collider2D[10];

    public bool OnGround
    {
        get
        {
            int hitCount = Physics2D.OverlapCircleNonAlloc(
                _groundCheck.position,
                _groundCheckDistance,
                _colliders,
                _groundMask
            );

            return hitCount > 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        if (_groundCheck != null)
        {
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckDistance);
        }
    }
}
