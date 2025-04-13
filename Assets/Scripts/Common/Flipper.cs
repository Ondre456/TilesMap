using UnityEngine;

public class Flipper : MonoBehaviour
{
    private const float GoLeft = 180;
    private const float GoRight = 0;

    private Quaternion _leftRotation = Quaternion.Euler(0, GoLeft, 0);
    private Quaternion _rightRotation = Quaternion.Euler(0, GoRight, 0);

    public void SetDirection(float horizontalMovementComponent)
    {
        bool isDirectionRight = false;
        bool isDirectionLeft = false;
        
        if (horizontalMovementComponent > 0)
        {
            isDirectionRight = true;
        }
        else if (horizontalMovementComponent < 0)
        {
            isDirectionLeft = true;
        }

        if (isDirectionRight)
        {
            transform.rotation = _rightRotation;
        }

        if (isDirectionLeft)
        {
            transform.rotation = _leftRotation;
        }
    }
}
