using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public enum BattleState {Start, PlayerTurn, EnemyTurn, Win, Lose}

public class BattleSystem : MonoBehaviour
{
    
    private GameObject player;
    private GameObject enemy;

    public walk walk;

    public Transform playerPos;
    public Transform enemyPos;

    public PlayerStats playerStats;
    public EnemyStats enemyStats;

    private BattleState battleState;

    public TextMeshProUGUI battleText;

    public Animator spellbook;

    public StatHUD playerStatHUD;
    public StatHUD enemyStatHUD;
    
    public KeepButtonHighlighted buttons;
    
    

    private GameManager gameManager;
    //private SymbolDrawing symbolDrawing;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        //symbolDrawing = FindObjectOfType<SymbolDrawing>();
        playerStatHUD = GameObject.FindWithTag("PlayerStats").GetComponent<StatHUD>();
        enemyStatHUD = GameObject.FindWithTag("EnemyStats").GetComponent<StatHUD>();
        buttons = FindObjectOfType<KeepButtonHighlighted>();
        
        battleState = BattleState.Start;
        StartCoroutine(StartBattle());
    }

    private void FixedUpdate()
    {
        SetPlayerStats();
        SetEnemyStats();
    }

    private IEnumerator StartBattle()
    {
        player = Instantiate(playerStats.playerGameObject, playerPos.position, Quaternion.identity);
        walk = player.GetComponent<walk>();
        //gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        enemy = Instantiate(enemyStats.enemyGameObject, enemyPos.position, Quaternion.identity);
        

        playerStats.health = playerStats.maxHealth;
        enemyStats.health = enemyStats.maxHealth;

        yield return new WaitForSeconds(0.01f);
        walk.canMove = false;

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
        buttons.AllInteractable();
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

        if (enemyStats.health >= gameManager.damage)
        {
            enemyStats.health -= gameManager.damage;
        }

        else
        {
            enemyStats.health -= enemyStats.health;
        }

        yield return new WaitForSeconds(3);

        if (enemyStats.health <= 0)
        {
            battleState = BattleState.Win;
            yield return StartCoroutine(EndBattle());
        }

        else
        {
            battleState = BattleState.EnemyTurn;
            yield return StartCoroutine(EnemyTurn());
        }

    }

    private IEnumerator EnemyTurn()
    {
        battleText.text = "It's " + enemyStats.enemyName + "'s turn!";

        yield return new WaitForSeconds(2);

        battleText.text = enemyStats.enemyName + " bites you!";

        yield return new WaitForSeconds(2);
        int enemyDamage = Random.Range(20, 30);
        battleText.text = "It dealt " + enemyDamage + " damage to you!";

        if (playerStats.health >= enemyDamage)
        {
            playerStats.health -= enemyDamage;
        }

        else
        {
            playerStats.health -= playerStats.health;
        }

        yield return new WaitForSeconds(3);

        if (playerStats.health <= 0)
        {
            battleState = BattleState.Lose;
            yield return StartCoroutine(EndBattle());
        }

        else
        {
            battleState = BattleState.PlayerTurn;
            yield return StartCoroutine(PlayerTurn());
        }

    }

    private IEnumerator EndBattle()
    {
        if (battleState == BattleState.Win)
        {
            battleText.text = "You won!";
            
            switch (enemyStats.enemyName)
            {
                case "Fire Book":
                    EnemyCheck.fireEnemyDead = true;
                    break;
                case "Water Book":
                    EnemyCheck.waterEnemyDead = true;
                    break;
                case "Moss Book":
                    EnemyCheck.mossEnemyDead = true;
                    break;
            }
            
            Destroy(enemy);

            PlayerSpawn.firstSpawn = false;


            yield return new WaitForSeconds(3);
            LevelLoader.instance.LoadLevel("gabScene");
            //LevelLoader.instance.LoadLevel("Battle System Test");
        }
        
        else if (battleState == BattleState.Lose)
        {
            battleText.text = "You lost... Time to try again!";
            Destroy(player);

            yield return new WaitForSeconds(3);
            LevelLoader.instance.LoadLevel("Battle Arena");

        }
    }


    private void SetPlayerStats()
    {
        float currentHealth = playerStats.health * (100 / playerStats.maxHealth);
        playerStatHUD.healthBar.fillAmount = currentHealth / 100;
        playerStatHUD.healthNumber.text = playerStats.health + "/" + playerStats.maxHealth;
    }

    private void SetEnemyStats()
    {
        float currentHealth = enemyStats.health * (100 / enemyStats.maxHealth);
        enemyStatHUD.healthBar.fillAmount = currentHealth / 100;
        enemyStatHUD.healthNumber.text = enemyStats.health + "/" + enemyStats.maxHealth;
    }

}
