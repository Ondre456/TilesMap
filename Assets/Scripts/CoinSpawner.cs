using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CoinPool))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _repeatRate = 3f;

    private CoinPool _coinPool;
    private Vector3 _position;

    private void Awake()
    {
        _position = transform.position;
        _coinPool = GetComponent<CoinPool>();
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Coin coin = _coinPool.Get();

        if (coin == null) 
            return;

        coin.enabled = true;
        coin.transform.position = _position;
        coin.Deactivated -= CoinDeactivated;
        coin.Deactivated += CoinDeactivated;
    }

    private void CoinDeactivated(Coin coin)
    {
        StartCoroutine(SpawnCourutine());
    }

    private IEnumerator SpawnCourutine()
    {
        yield return new WaitForSeconds(_repeatRate);

        Spawn();
    }
}
