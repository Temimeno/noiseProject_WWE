using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] GameObject dropItemPrefab;
    [SerializeField] [Range(0f,1f)] float chance = 1f;

    bool isQuitting = false;

    private void OnAppQuit()
    {
        isQuitting = true;
    }
    private void OnDestroy()
    {
        if (isQuitting)
        {
            return;
        }

        if(Random.value < chance)
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }
    }
}
