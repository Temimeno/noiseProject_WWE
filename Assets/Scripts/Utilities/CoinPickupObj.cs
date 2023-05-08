using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickupObj : MonoBehaviour, iPickupObject
{
    [SerializeField] int count;

    public void OnPickup(playerStats playerStats)
    {
        playerStats.coin.Add(count);
    }
}
