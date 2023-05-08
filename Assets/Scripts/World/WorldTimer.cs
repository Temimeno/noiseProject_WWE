using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    public float time;
    TimeUI timeUI;

    private void Awake()
    {
        timeUI = FindObjectOfType<TimeUI>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeUI.UpdateTime(time);
    }
}
