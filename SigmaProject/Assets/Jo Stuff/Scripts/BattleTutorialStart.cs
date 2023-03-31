using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTutorialStart : MonoBehaviour
{
    public GameObject choice;
    public GameObject canvas;
    public GameObject player;
    public DialogueManager dialogueManager;
    public PlayerStats playerStats;
    public EnemyStats enemyStats;
    public static bool tutorialBattleStart = false;

    public Transform goblinPos;

    public EnemyStats status;

    private void Start()
    {
        choice.SetActive(false);
        status = gameObject.GetComponent<Enemy>().enemyStats;
        enemyStats.enemyName = status.enemyName;
        enemyStats.enemyGameObject = status.enemyGameObject;
        enemyStats.maxHealth = status.maxHealth;
        enemyStats.health = status.health;
        enemyStats.attack1 = status.attack1;
        enemyStats.attack2 = status.attack2;
        enemyStats.attack3 = status.attack3;

        if (TutorialBattleSystem.tutorialDone)
        {
            gameObject.transform.position = goblinPos.position;
        }


    }

    private void Update()
    {
        if (dialogueManager.sentences.Count == 0 && !tutorialBattleStart)
        {
            choice.SetActive(true);
        }

        else
        {
            choice.SetActive(false);
        }

    }
    
    public void StartTutorialBattle()
    {
        SymbolDrawing.isTutorial = true;
        player = GameObject.FindWithTag("Player");
        canvas.SetActive(false);
        tutorialBattleStart = true;
        LevelLoader.instance.LoadLevel("Battle Tutorial");
        SetBattleData();
    }

    private void SetBattleData()
    {
        playerStats.position[0] = player.transform.parent.position.x;
        playerStats.position[1] = player.transform.parent.position.y;
    }

    public void NoTutorialBattle()
    {
        canvas.SetActive(false);
        dialogueManager.EndDialogue();
    }
}
