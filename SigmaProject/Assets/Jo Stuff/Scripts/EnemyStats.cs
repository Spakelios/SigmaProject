using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsData", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStats : ScriptableObject
{

    public string enemyName;
    public GameObject enemyGameObject;
    public float maxHealth;
    public float health;
    
}
