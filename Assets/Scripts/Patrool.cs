using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Flipper))]
public class Patrool : MonoBehaviour
{
    [SerializeField] private List<Vector2> _points = new List<Vector2>();
    [SerializeField] private float _distanceThreshold = 0.1f;
    [SerializeField] private float _speed = 2f;

    private int _index = 0;
    private Vector2 _currentGoal;
    private Rigidbody2D _rigidbody;
    private Flipper _directionChanger;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _directionChanger = GetComponent<Flipper>();
    }

    public void Move()
    {
        if (_points.Count == 0)
            return;

        Vector2 targetPosition = _points[_index % _points.Count];
        Vector2 currentPosition = _rigidbody.position;
        Vector2 direction = (targetPosition - currentPosition).normalized;
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = direction.x * _speed;

        _rigidbody.velocity = velocity;
        _directionChanger.SetDirection(velocity.x);

        if (Mathf.Abs(currentPosition.x - targetPosition.x) < _distanceThreshold)
        {
            _index++;
        }
    }
}
