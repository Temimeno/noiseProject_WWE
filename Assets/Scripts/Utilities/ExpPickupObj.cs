using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickupObj : MonoBehaviour, iPickupObject
{

    [SerializeField] int amount;

    public void OnPickup(playerStats playerStats)
    {
        playerStats.level.AddExperience(amount);
    }
}
