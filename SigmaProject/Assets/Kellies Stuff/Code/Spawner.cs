using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Player Settings")] public GameObject player;
    [Header("SpawnPoints")] public Transform[] spawns;
    [Header("Room SetUp")] public GameObject SpawnPoint;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SpawnPoint.SetActive(true);
            player.transform.position = spawns[0].transform.position;
            player.transform.rotation = spawns[0].transform.rotation;
        }
    }
    
}

