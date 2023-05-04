using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public enum TutorialBattleState {Start, PlayerTurn, EnemyTurn, End}

public class TutorialBattleSystem : MonoBehaviour
{
    private GameObject player;
    public GameObject enemy;

    public walk walk;

    public Transform playerPos1;
    public Transform enemyPos1;

    public Transform camPos1;

    public PlayerStats playerStats;
    public EnemyStats enemyStats;

    public Animator playerAnimator;
    public Animator enemyAnimator;

    private TutorialBattleState battleState;

    public TextMeshProUGUI battleText;

    public Animator spellbook;

    public StatHUD playerStatHUD;
    public StatHUD enemyStatHUD;

    public KeepButtonHighlighted buttons;

    public bool mouseClick;

    public int attackChance;
    private int enemyDamage;

    private GameManager gameManager;

    public GameObject advanceDialogueText;

    public static bool tutorialDone;

    public AudioSource spellSound;
    
    private GameObject spell;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        //symbolDrawing = FindObjectOfType<SymbolDrawing>();
        playerStatHUD = GameObject.FindWithTag("PlayerStats").GetComponent<StatHUD>();
        enemyStatHUD = GameObject.FindWithTag("EnemyStats").GetComponent<StatHUD>();
        buttons = FindObjectOfType<KeepButtonHighlighted>();

        battleState = TutorialBattleState.Start;
        StartCoroutine(StartBattle());
        mouseClick = false;
    }

    // Update is called once per frame
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
        player = Instantiate(playerStats.playerGameObject, playerPos1.position, Quaternion.identity);
        enemy = Instantiate(enemyStats.enemyGameObject, enemyPos1.position, Quaternion.identity);
        //gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
        Camera.main.transform.position = camPos1.position;


        walk = player.GetComponent<walk>();
        playerStats.health = playerStats.maxHealth;
        enemyStats.health = enemyStats.maxHealth;

        playerAnimator = player.GetComponent<Animator>();
        enemyAnimator = enemy.GetComponent<Animator>();


        yield return new WaitForEndOfFrame();
        walk.canMove = false;

        battleText.text = "You can never be too prepared, right? It's always good to have a refresher, just in case.";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleState = TutorialBattleState.PlayerTurn;
        yield return StartCoroutine(PlayerTurn());
    }

    private IEnumerator PlayerTurn()
    {
        battleText.text =
            "So on the battle screen, you'll see a few things, like this text box right here. This is where all info about attacks will go.";
        advanceDialogueText.SetActive(true);

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;
        battleText.text =
            "Above us you'll see HP bars: the green one is yours and the red one is the enemy's. Your aim here is to bring your enemy's HP down to 0.";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text =
            "And how will you do that? Well, with spells of course! You're a wizard, after all, how else would you do it?";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text =
            "On your turn, your spellbook will slide up. Click a spell type on the left page, and hold down left click to draw the symbol that shows up on the right page as accurately as you can. Follow the stencil!";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text = "Well then, let's see what you've got!";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

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
        battleText.text = gameManager.damageRank + gameManager.damageEffectiveness + " You dealt " +
                          gameManager.damage + " damage to " + enemyStats.enemyName + "!";

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

        battleText.text =
            "How'd you do? Remember, the more accurately you follow the stencil, the more damage you'll do! And be careful, if your drawing is too inaccurate, you won't do any damage at all!";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text =
            "Oh, and one more thing. Enemies will have different elemental types, so your spells might do more or less damage depending on how effective the spell type is against the enemy type.";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text = "Now then, if the enemy's still around after your turn, it'll be its turn next.";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text =
            "Enemies will attack you for anywhere between 20 and 30 damage. However, they also have a chance to miss their attack completely!";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text =
            "Now I'll let this guy right here try and attack you. Don't worry, I won't let you get hurt too badly!";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleState = TutorialBattleState.EnemyTurn;
        yield return StartCoroutine(EnemyTurn());
    }

    private IEnumerator EnemyTurn()
    {

        battleText.text = "It's " + enemyStats.enemyName + "'s turn!";

        attackChance = Random.Range(1, 11);

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        if (attackChance <= 7) //70% chance to hit
        {
            battleText.text = enemyStats.enemyName + " drains your energy with moss!";
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

        battleText.text =
            "That wasn't so bad now, was it? If your HP didn't hit 0 after an enemy's turn, it'll be your turn again. Rinse and repeat until one of you defeats the other.";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleState = TutorialBattleState.End;
        yield return StartCoroutine(EndBattle());
    }

    private IEnumerator EndBattle()
    {
        battleText.text =
            "And that's about it! After the battle you'll either be transported back to the Overworld if you won, or the battle will start again if you lost.";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text =
            "Oh, and don't worry about your HP after you win a battle. It'll be restored back up to full, so you'll be in top form for your next battle!";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;

        battleText.text =
            "Now off you go, time to save the library. If you want a tutorial again, you know where to find me!";

        yield return new WaitUntil(() => mouseClick);
        mouseClick = false;
        BattleTutorialStart.tutorialBattleStart = false;
        SymbolDrawing.isTutorial = false;
        tutorialDone = true;
        LevelLoader.instance.LoadLevel("gabScene");
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
