using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CoinPool))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _repeatPeriod = 3f;

    private CoinPool _coinPool;
    private Vector3 _position;
    private WaitForSeconds _coinSpawnDelayer;

    private void Awake()
    {
        _position = transform.position;
        _coinPool = GetComponent<CoinPool>();
        _coinSpawnDelayer = new WaitForSeconds(_repeatPeriod);
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Coin coin = _coinPool.Get();

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
        yield return _coinSpawnDelayer;

        Spawn();
    }
}
