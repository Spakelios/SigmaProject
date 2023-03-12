using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public PlayerStats playerStats;
    private GameObject player;
    private Vector3 playerPos;
    private CinemachineVirtualCamera camera;

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

        camera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        camera.Follow = player.transform;

    }

}
