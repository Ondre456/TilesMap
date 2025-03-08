using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 8f;

    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    public void TryJump()
    {
        if (_groundChecker.OnGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}
