using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageProgression : MonoBehaviour
{
    WorldTimer worldTimer;

    private void Awake()
    {
        worldTimer = GetComponent<WorldTimer>();
    }

    [SerializeField] float progressTimeRate = 30F;
    [SerializeField] float progessPerSplit = 0.2f;

    public float Progress
    {
        get
        {
             return 1f + worldTimer.time / progressTimeRate * progessPerSplit;
        }
    }
}
