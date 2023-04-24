using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public SymbolDrawing symbolDrawing;
    public BattleSystem battleSystem;
    public TutorialBattleSystem tutorialBattle;
    public EnemyStats enemyStats;

    private int okDamage;
    private int goodDamage;
    private int greatDamage;
    private int amazingDamage;

    //public TextMeshProUGUI damageText;
    //public TextMeshProUGUI damageType;

    public string spell;
    public string damageRank;
    public int damage;
    public string damageEffectiveness;

    private string enemyType;

    private float strongElement;
    private float weakElement;
    private int neutralElement;

    public float multiplier;

    public AudioClip fireSound;
    public AudioClip waterSound;
    public AudioClip mossSound;
    




    private void Start()
    {
        symbolDrawing = FindObjectOfType<SymbolDrawing>();
        battleSystem = FindObjectOfType<BattleSystem>();
        tutorialBattle = FindObjectOfType<TutorialBattleSystem>();

        strongElement = 1.5f;
        neutralElement = 1;
        weakElement = 0.5f;

        /*
        damageText.text = "";
        damageType.text = "";
        */

    }

    public void TypeChart()
    {
        //strong element = 1.5x multiplier
        //weak element = 0.5x multiplier
        //same element = 1x multiplier

        enemyType = enemyStats.enemyName switch
        {
            "Fire Book" => "Fire",
            "Water Book" => "Water",
            "Moss Book" => "Moss",
            "???" => "None",
            _ => enemyType
        };

        multiplier = enemyType switch
        {
            //fire type chart
            "Fire" when spell == "Fireball" => neutralElement,
            "Fire" when spell == "Waterfall" => strongElement,
            "Fire" when spell == "Mossy Overgrowth" => weakElement,
            //water type chart
            "Water" when spell == "Fireball" => weakElement,
            "Water" when spell == "Waterfall" => neutralElement,
            "Water" when spell == "Mossy Overgrowth" => strongElement,
            //moss type chart
            "Moss" when spell == "Fireball" => strongElement,
            "Moss" when spell == "Waterfall" => weakElement,
            "Moss" when spell == "Mossy Overgrowth" => neutralElement,
            //goblin tutorial
            "None" when spell == "Fireball" => neutralElement,
            "None" when spell == "Waterfall" => neutralElement,
            "None" when spell == "Mossy Overgrowth" => neutralElement,
            _ => multiplier
        };
        
        CalculateDamage();
    }

    private void CalculateDamage()
    {
        if (symbolDrawing.gestureResult.Score <= 0.6f) //50% - 60%
        {
            okDamage = Random.Range(50, 61);
            damageRank = "It was an OK spell";
            damage = (int) (okDamage * multiplier);
            /*
            damageType.text = "OK spell";
            damageText.text = "Damage Dealt: " + okDamage;
            */
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.61f && symbolDrawing.gestureResult.Score <= 0.7f) //61% - 70%
        {
            goodDamage = Random.Range(61, 71);
            damageRank = "It was a good spell";
            damage = (int) (goodDamage * multiplier);
            /*
            damageType.text = "Good spell";
            damageText.text = "Damage Dealt: " + goodDamage;
            */
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.71f && symbolDrawing.gestureResult.Score <= 0.8f) //71% - 80%
        {
            greatDamage = Random.Range(71, 81);
            damageRank = "It was a great spell";
            damage = (int) (greatDamage * multiplier);
            /*
            damageType.text = "Great spell!";
            damageText.text = "Damage Dealt: " + greatDamage;
            */
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.81f) //81% or higher
        {
            amazingDamage = Random.Range(81, 91);
            damageRank = "It was an amazing spell";
            damage = (int) (amazingDamage * multiplier);
            /*
            damageType.text = "Amazing spell!";
            damageText.text = "Damage Dealt: " + amazingDamage;
            */
        }
        
        ContinueBattle();
    }

    public void SpellFailed()
    {
        /*
        damageText.text = "";
        damageType.text = "";
        */

        spell = "some sort of spell";
        damageRank = "But something went wrong! Your drawing didn't look right...";
        damage = 0;
        multiplier = 0;
        
        ContinueBattle();
    }

    private void ContinueBattle()
    {
        //print("Multiplier: " + multiplier + " Damage: " + damage);
        if (multiplier == weakElement)
        {
            damageEffectiveness = ", but it isn't very effective.";
        }
        
        else if (multiplier == neutralElement)
        {
            damageEffectiveness = ", and it's somewhat effective.";
        }
        
        else if (multiplier == strongElement)
        {
            damageEffectiveness = ", and it's super effective!";
        }

        else
        {
            damageEffectiveness = null;
        }

        if (!SymbolDrawing.isTutorial)
        {
            battleSystem.spellSound.clip = spell switch
            {
                "Fireball" => fireSound,
                "Waterfall" => waterSound,
                "Mossy Overgrowth" => mossSound,
                _ => null
            };
            battleSystem.ContinuePlayerTurn();
        }

        else
        {
            tutorialBattle.spellSound.clip = spell switch
            {
                "Fireball" => fireSound,
                "Waterfall" => waterSound,
                "Mossy Overgrowth" => mossSound,
                _ => null
            };
            
            tutorialBattle.ContinuePlayerTurn();
        }
        
        symbolDrawing.BookDown();
    }
}
