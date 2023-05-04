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

    public Transform playerPos1;
    public Transform enemyPos1;

    public Transform playerPos2;
    public Transform enemyPos2;

    public Transform camPos1;
    public Transform camPos2;

    public PlayerStats playerStats;
    public EnemyStats enemyStats;

    public Animator playerAnimator;
    public Animator enemyAnimator;

    private BattleState battleState;

    public TextMeshProUGUI battleText;

    public Animator spellbook;

    public StatHUD playerStatHUD;
    public StatHUD enemyStatHUD;
    
    public KeepButtonHighlighted buttons;

    public bool mouseClick;

    public List<string> enemyAttacks;
    public int attackNumber;
    public int attackChance;
    private int enemyDamage;
    
    private GameManager gameManager;

    public static bool firstBattleDone = false;

    public AudioSource battleMusic;
    public AudioSource victoryJingle;
    public AudioSource defeatJingle;
    public AudioSource spellSound;

    public GameObject advanceDialogueText;

    private GameObject spell;
    
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
        mouseClick = false;
        enemyAttacks = new List<string>();


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            mouseClick = true;
        }
    }

    private void FixedUpdate()
    {
        SetPlayerStats();
        SetEnemyStats();
    }

    private IEnumerator StartBattle()
    {
        if (!firstBattleDone)
        {
            player = Instantiate(playerStats.playerGameObject, playerPos1.position, Quaternion.identity);
            //gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            enemy = Instantiate(enemyStats.enemyGameObject, enemyPos1.position, Quaternion.identity);
            Camera.main.transform.position = camPos1.position;
        }

        else
        {
            player = Instantiate(playerStats.playerGameObject, playerPos2.position, Quaternion.identity);
            //gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            enemy = Instantiate(enemyStats.enemyGameObject, enemyPos2.position, Quaternion.identity);
            Camera.main.transform.position = camPos2.position;
        }
        
        walk = player.GetComponent<walk>();
        playerStats.health = playerStats.maxHealth;
        enemyStats.health = enemyStats.maxHealth;
        playerAnimator = player.GetComponent<Animator>();
        enemyAnimator = enemy.GetComponent<Animator>();


        yield return new WaitForEndOfFrame();
        walk.canMove = false;

        battleText.text = enemyStats.enemyName + " has appeared!";
        
        enemyAttacks.Add(enemyStats.attack1);
        enemyAttacks.Add(enemyStats.attack2);
        enemyAttacks.Add(enemyStats.attack3);
        
        
        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleState = BattleState.PlayerTurn;
        yield return StartCoroutine(PlayerTurn());

    }

    private IEnumerator PlayerTurn()
    {
        battleText.text = playerStats.playerName + "! It's your turn!";
        advanceDialogueText.SetActive(true);

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text = "";
        spellbook.SetTrigger("SlideUp");
        advanceDialogueText.SetActive(false);
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
        mouseClick = false;
        

        spellSound.Play();
        

        if (gameManager.currentSpell != null)
        {
            spell = Instantiate(gameManager.currentSpell, enemy.transform.position, Quaternion.identity);
        }
        
        playerAnimator.Play("Spellcast");
        battleText.text = playerStats.playerName + " casts " + gameManager.spell + "!";
        advanceDialogueText.SetActive(true);
        
        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;
        if (spell != null)
        {
            Destroy(spell);
        }

        battleText.text = gameManager.damageRank + gameManager.damageEffectiveness + " You dealt " + gameManager.damage + " damage to " + enemyStats.enemyName + "!";

        if (enemyStats.health >= gameManager.damage)
        {
            enemyStats.health -= gameManager.damage;
        }

        else
        {
            enemyStats.health -= enemyStats.health;
        }

        if (enemyStats.health <= 100)
        {
            enemyAnimator.SetBool("isDamaged", true);
        }

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

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

        attackChance = Random.Range(1, 11);

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        if (attackChance <= 7) //70% chance to hit
        {
            attackNumber = Random.Range(0, 3);

            battleText.text = enemyStats.enemyName + " " + enemyAttacks[attackNumber];
            enemyDamage = Random.Range(20, 31);
        }

        else //30% chance to miss
        {
            enemyDamage = 0;

            battleText.text = enemyStats.enemyName + " tries to attack you, but missed!";
        }
        
        enemyAnimator.SetBool("isAttacking", true);
        
        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;
        battleText.text = "It dealt " + enemyDamage + " damage to you!";

        if (playerStats.health >= enemyDamage)
        {
            playerStats.health -= enemyDamage;
        }

        else
        {
            playerStats.health -= playerStats.health;
        }

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;
        
        enemyAnimator.SetBool("isAttacking", false);

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
            battleMusic.Stop();
            victoryJingle.Play();
            
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
            firstBattleDone = true;


            yield return new WaitUntil(() => mouseClick);
            mouseClick = false;
            LevelLoader.instance.LoadLevel("gabScene");
            //LevelLoader.instance.LoadLevel("Battle System Test");
        }
        
        else if (battleState == BattleState.Lose)
        {
            battleText.text = "You lost... Time to try again!";
            battleMusic.Stop();
            defeatJingle.Play();
            Destroy(player);

            yield return new WaitUntil(() => mouseClick);
            mouseClick = false;
            
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
