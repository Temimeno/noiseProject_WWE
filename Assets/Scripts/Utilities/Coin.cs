using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinAcquired;
    [SerializeField] TMPro.TextMeshProUGUI coinCountText;

    public void Add(int count)
    {
        coinAcquired += count;
        coinCountText.text = "COIN   : " + coinAcquired.ToString();
    }
}
