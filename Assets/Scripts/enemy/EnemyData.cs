using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string name;
    public GameObject animatedPrfab;
    public EnemyStats stats;
}
    
