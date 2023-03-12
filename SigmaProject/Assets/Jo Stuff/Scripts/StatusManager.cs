using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    
    public PlayerStats playerStats;
    public EnemyStats enemyStats;



    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            gameObject.transform.parent.GetComponent<walk>().canMove = false;
            gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            SetBattleData(other);
            LevelLoader.instance.LoadLevel("Battle Arena");
        }


    }

    private void SetBattleData(Collider2D other)
    {
        //Player Data
        playerStats.position[0] = gameObject.transform.parent.position.x;
        playerStats.position[1] = gameObject.transform.parent.position.y;
        
        //Enemy Data
        EnemyStats status = other.gameObject.GetComponent<Enemy>().enemyStats;
        
        enemyStats.enemyName = status.enemyName;
        enemyStats.enemyGameObject = status.enemyGameObject;
        enemyStats.maxHealth = status.maxHealth;
        enemyStats.health = status.health;
        
        //enemyStats = status;

    }
}
