using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleStates {Start, PlayerTurn, EnemyTurn}

public class BattleSystem : MonoBehaviour
{
    public GameObject player;
    public walk playerMovement;
    public GameObject enemy;

    public Transform playerPos;
    public Transform enemyPos;

    public BattleStates state;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<walk>();
        enabled = false;
    }

    private void OnEnable()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerMovement.enabled = false;

        state = BattleStates.Start;
        BattleSetup();

    }

    private void BattleSetup()
    {
        player.transform.position = playerPos.position;
        enemy.transform.position = enemyPos.position;
        
        //insert everything about stats here
        
        
    }
}
