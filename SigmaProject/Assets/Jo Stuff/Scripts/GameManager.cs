using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public SymbolDrawing symbolDrawing;
    public BattleSystem battleSystem;
    
    private int okDamage;
    private int goodDamage;
    private int greatDamage;
    private int amazingDamage;

    //public TextMeshProUGUI damageText;
    //public TextMeshProUGUI damageType;

    public string spell;
    public string damageRank;
    public int damage;




    void Start()
    {
        symbolDrawing = FindObjectOfType<SymbolDrawing>();
        battleSystem = FindObjectOfType<BattleSystem>();
        /*
        damageText.text = "";
        damageType.text = "";
        */

    }

    public void CalculateDamage()
    {
        if (symbolDrawing.gestureResult.Score <= 0.75f)
        {
            okDamage = Random.Range(70, 76);
            damageRank = "It was an OK spell.";
            damage = okDamage;
            /*
            damageType.text = "OK spell";
            damageText.text = "Damage Dealt: " + okDamage;
            */
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.76f && symbolDrawing.gestureResult.Score <= 0.85f)
        {
            goodDamage = Random.Range(76, 86);
            damageRank = "It was a good spell.";
            damage = goodDamage;
            /*
            damageType.text = "Good spell";
            damageText.text = "Damage Dealt: " + goodDamage;
            */
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.86f && symbolDrawing.gestureResult.Score <= 0.94f)
        {
            greatDamage = Random.Range(86, 95);
            damageRank = "It was a great spell!";
            damage = greatDamage;
            /*
            damageType.text = "Great spell!";
            damageText.text = "Damage Dealt: " + greatDamage;
            */
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.95f)
        {
            amazingDamage = Random.Range(95, 101);
            damageRank = "It was an amazing spell!";
            damage = amazingDamage;
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
        battleSystem.ContinuePlayerTurn();
        symbolDrawing.BookDown();
    }
}
