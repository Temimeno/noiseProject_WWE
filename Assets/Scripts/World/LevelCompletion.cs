using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;
    WorldTimer worldTimer;
    WinManager winManager;
    [SerializeField] TimeOut timeOutPanel;

    private void Awake()
    {
        worldTimer = GetComponent<WorldTimer>();
        timeOutPanel = FindObjectOfType<TimeOut>(true);
    }

    public void Update()
    {
        if (worldTimer.time > timeToCompleteLevel)
        {
            Time.timeScale = 0f;
            timeOutPanel.gameObject.SetActive(true);
        }
    }
}
