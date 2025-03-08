using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    private Rigidbody2D _rigidbody;
    private bool _onGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void TryJump()
    {
        Debug.Log("sdf");

        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckDistance, _groundMask);

        if (_onGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
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
