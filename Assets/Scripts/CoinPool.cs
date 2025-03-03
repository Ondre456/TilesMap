using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private int _maxPoolSize = 1;
    [SerializeField] private int _poolCapacity = 1;

    private ObjectPool<Coin> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
                createFunc: () => CreateFunction(),
                actionOnGet: (obj) => ActionOnGet(obj),
                actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _maxPoolSize
            );
    }

    public Coin Get()
    {
        return _pool?.Get();
    }

    private Coin CreateFunction()
    {
        Coin instance = Instantiate(_prefab);

        if (instance.TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            spriteRenderer.enabled = true;
        }

        if (instance.TryGetComponent(out BoxCollider2D collider))
        {
            collider.enabled = true;
        }

        return instance;
    }

    private void ActionOnGet(Coin coin)
    {
        coin.gameObject.SetActive(true);
        coin.Deactivated += OnCoinDeactivated;
    }

    private void OnCoinDeactivated(Coin coin)
    {
        _pool.Release(coin);
        coin.Deactivated -= OnCoinDeactivated;
    }
}
