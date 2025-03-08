using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    public bool OnGround => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckDistance, _groundMask);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        if (_groundCheck != null)
        {
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckDistance);
        }
    }
}
