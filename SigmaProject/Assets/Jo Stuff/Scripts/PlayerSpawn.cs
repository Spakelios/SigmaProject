using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public PlayerStats playerStats;
    private GameObject player;
    private Vector3 playerPos;

    public static bool firstSpawn = true;
    private Transform firstSpawnPos;
    private void Start()
    {
        playerPos = new Vector3(playerStats.position[0], playerStats.position[1], 0);
        firstSpawnPos = GameObject.FindWithTag("FirstSpawn").transform;

        if (firstSpawn)
        {
            player = Instantiate(playerStats.playerGameObject, firstSpawnPos.position, Quaternion.identity);
        }

        else
        {
            player = Instantiate(playerStats.playerGameObject, playerPos, Quaternion.identity);
        }

    }

}
