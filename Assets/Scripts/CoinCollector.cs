using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class CoinCollector : MonoBehaviour
{
    [SerializeField] private int _collectedCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _collectedCount++;
            coin.Deactivate();
        }
    }
}
