using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;

    public void GameOver()
    {
        GetComponent<NewController>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
    }
}
