using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectSpawner : MonoBehaviour
{
    public PlayerStats playerStats;
    public Transform spawnPos;
    public Transform unavailableAreaSpawn;
    private GameObject player;
    private GameObject lighting;


    private void Start()
    {
        player = Instantiate(playerStats.playerGameObject, spawnPos.position, Quaternion.identity);
        player.transform.Find("Lighting").gameObject.SetActive(true);
    }

    public void UnavailableArea()
    {
        player.GetComponent<walk>().canMove = false;
        player.transform.position = unavailableAreaSpawn.position;
    }

    public void ReturnToLevelSelect()
    {
        player.GetComponent<walk>().canMove = true;
        player.transform.position = spawnPos.position;
    }
}
