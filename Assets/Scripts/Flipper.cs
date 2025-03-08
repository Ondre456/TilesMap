using UnityEngine;

public class Flipper : MonoBehaviour
{
    private const float GoLeft = 180;
    private const float GoRight = 0;

    private bool IsDirectionRight;
    private bool IsDirectionLeft;

    private void FixedUpdate()
    {
        if (IsDirectionRight)
        {
            transform.rotation = new Quaternion(0, GoRight, 0, 0);
        }
        if (IsDirectionLeft)
        {
            transform.rotation = new Quaternion(0,GoLeft,0,0);
        }
    }

    public void SetDirection(float speed)
    {
        if (speed > 0)
        {
            IsDirectionRight = true;
            IsDirectionLeft = false;
        }
        else if (speed < 0)
        {
            IsDirectionLeft = true;
            IsDirectionRight = false;
        }
        else if (speed == 0)
        {
            IsDirectionLeft = false;
            IsDirectionRight = false;
        }
    }
}
