using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectSpawner : MonoBehaviour
{
    public PlayerStats playerStats;
    public Transform spawnPos;
    private GameObject player;
    private GameObject lighting;


    private void Start()
    {
        player = Instantiate(playerStats.playerGameObject, spawnPos.position, Quaternion.identity);
        player.transform.Find("Lighting").gameObject.SetActive(true);


    }
}
