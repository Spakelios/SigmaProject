using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public SymbolDrawing symbolDrawing;
    public BattleSystem battleSystem;
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

    private string enemyType;

    private float strongElement;
    private float weakElement;
    private int neutralElement;

    public float multiplier;




    private void Start()
    {
        symbolDrawing = FindObjectOfType<SymbolDrawing>();
        battleSystem = FindObjectOfType<BattleSystem>();

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
            _ => multiplier
        };

        CalculateDamage();
    }

    private void CalculateDamage()
    {
        if (symbolDrawing.gestureResult.Score <= 0.75f)
        {
            okDamage = Random.Range(50, 60);
            damageRank = "It was an OK spell.";
            damage = (int) (okDamage * multiplier);
            /*
            damageType.text = "OK spell";
            damageText.text = "Damage Dealt: " + okDamage;
            */
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.76f && symbolDrawing.gestureResult.Score <= 0.85f)
        {
            goodDamage = Random.Range(60, 70);
            damageRank = "It was a good spell.";
            damage = (int) (goodDamage * multiplier);
            /*
            damageType.text = "Good spell";
            damageText.text = "Damage Dealt: " + goodDamage;
            */
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.86f && symbolDrawing.gestureResult.Score <= 0.94f)
        {
            greatDamage = Random.Range(70, 80);
            damageRank = "It was a great spell!";
            damage = (int) (greatDamage * multiplier);
            /*
            damageType.text = "Great spell!";
            damageText.text = "Damage Dealt: " + greatDamage;
            */
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.95f)
        {
            amazingDamage = Random.Range(80, 91);
            damageRank = "It was an amazing spell!";
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

        spell = "a spell";
        damageRank = "But something went wrong! Your drawing didn't look right...";
        damage = 0;
        
        ContinueBattle();
    }

    private void ContinueBattle()
    {
        print("Multiplier: " + multiplier + " Damage: " + damage);
        battleSystem.ContinuePlayerTurn();
        symbolDrawing.BookDown();
    }
}
