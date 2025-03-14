using UnityEngine;

public class Flipper : MonoBehaviour
{
    private const float GoLeft = 180;
    private const float GoRight = 0;

    private bool _isDirectionRight;
    private bool _isDirectionLeft;

    private void FixedUpdate()
    {
        if (_isDirectionRight)
        {
            transform.rotation = Quaternion.Euler(0, GoRight, 0);
        }
        if (_isDirectionLeft)
        {
            transform.rotation = Quaternion.Euler(0,GoLeft,0);
        }
    }

    public void SetDirection(float speed)
    {
        if (speed > 0)
        {
            _isDirectionRight = true;
            _isDirectionLeft = false;
        }
        else if (speed < 0)
        {
            _isDirectionLeft = true;
            _isDirectionRight = false;
        }
        else if (speed == 0)
        {
            _isDirectionLeft = false;
            _isDirectionRight = false;
        }
    }
}
