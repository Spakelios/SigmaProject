using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState {Start, PlayerTurn, EnemyTurn}

public class BattleSystem : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;

    public Transform playerPos;
    public Transform enemyPos;

    public PlayerStats playerStats;
    public EnemyStats enemyStats;

    private BattleState battleState;

    public TextMeshProUGUI battleText;

    public Animator spellbook;
    

    private GameManager gameManager;
    private SymbolDrawing symbolDrawing;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        symbolDrawing = FindObjectOfType<SymbolDrawing>();
        
        battleState = BattleState.Start;
        StartCoroutine(StartBattle());
        
    }

    private IEnumerator StartBattle()
    {
        player = Instantiate(playerStats.playerGameObject);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<walk>().enabled = false;
        player.transform.position = playerPos.position;
        
        enemy = Instantiate(enemyStats.enemyGameObject);
        enemy.transform.position = enemyPos.position;

        battleText.text = "A " + enemyStats.enemyName + " has appeared!";
        yield return new WaitForSeconds(3);

        battleState = BattleState.PlayerTurn;
        yield return StartCoroutine(PlayerTurn());

    }

    private IEnumerator PlayerTurn()
    {
        battleText.text = playerStats.playerName + "! It's your turn!";

        yield return new WaitForSeconds(3);

        battleText.text = "";
        spellbook.SetTrigger("SlideUp");
    }

    public void ContinuePlayerTurn()
    {
        StartCoroutine(PlayerCastsSpell());
    }

    private IEnumerator PlayerCastsSpell()
    {
        spellbook.SetTrigger("SlideDown");
        

        yield return new WaitForSeconds(1);

        battleText.text = playerStats.playerName + " casts " + gameManager.spell + "!";
        
        yield return new WaitForSeconds(2);

        battleText.text = gameManager.damageRank + " You dealt " + gameManager.damage + " damage to " + enemyStats.enemyName + "!";
        
        yield return new WaitForSeconds(3);

        battleText.text = "ok that's it for now I'll finish the rest of the system either tomorrow or Friday";

    }

}
