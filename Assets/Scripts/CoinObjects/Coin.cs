using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Coin : MonoBehaviour
{
    public event Action<Coin> Deactivated;

    public void Deactivate()
    {
        Deactivated?.Invoke(this);
    }
}
