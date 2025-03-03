using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
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

    private void Update()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckDistance, _groundMask);

        if (Input.GetButtonDown("Jump") && _onGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
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
