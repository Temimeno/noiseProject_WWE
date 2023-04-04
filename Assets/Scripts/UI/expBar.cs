using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class expBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    public void UpdateExpSlider(int current, int target)
    {
        slider.maxValue = target;
        slider.value = current;
    }

    public void SetLevelText(int level)
    {
        levelText.text = "LEVEL: " + level.ToString();
    }

}
