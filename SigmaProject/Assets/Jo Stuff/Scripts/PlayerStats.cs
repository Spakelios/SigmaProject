using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStatsData", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{

    public string playerName;
    public float[] position = new float[2];
    public GameObject playerGameObject;
    public float maxHealth;
    public float health;

}
