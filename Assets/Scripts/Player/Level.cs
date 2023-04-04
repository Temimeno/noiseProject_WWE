using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] expBar expbar;


    int To_Level_Up
    {
        get
        {
            return level * 1000;
        }
    }

    void Start()
    {
        expbar.UpdateExpSlider(experience, To_Level_Up);
        expbar.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        expbar.UpdateExpSlider(experience, To_Level_Up);
    }

    public void CheckLevelUp()
    {
        if(experience >= To_Level_Up)
        {
            experience -= To_Level_Up;
            level += 1;
            expbar.SetLevelText(level);
        }
    }
}
