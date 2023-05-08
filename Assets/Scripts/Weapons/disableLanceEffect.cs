using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableLanceEffect : MonoBehaviour
{
    [SerializeField] float timToDisable = 0.8f;
    float timer;

    void OnEnable()
    {
        timer = timToDisable;
    }

    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
