using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Flipper))]
public class Pursuer : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Player _goal;
    private Rigidbody2D _rigidbody;
    private Flipper _flipper;

    public bool IsPurse { get => _goal != null; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
    }

    public void Purse()
    {
        Vector2 targetPosition = _goal.transform.position;
        Vector2 currentPosition = _rigidbody.position;
        Vector2 direction = (targetPosition - currentPosition).normalized;
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = direction.x * _speed;

        _rigidbody.velocity = velocity;
        _flipper.SetDirection(velocity.x);
    }

    public void AcceptGoal(Player goal)
    {
        _goal = goal;
    }

    public void LooseGoal()
    {
        _goal = null;
    }
}
