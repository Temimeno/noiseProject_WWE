using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] GameObject winMessegePanel;

    public void Win()
    {
        Time.timeScale = 0f;
        winMessegePanel.SetActive(true);
    }
}
