using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    private SymbolDrawing symbolDrawing;

    private int okDamage;
    private int goodDamage;
    private int greatDamage;
    private int amazingDamage;

    public TextMeshProUGUI damageText;
    public TextMeshProUGUI damageType;
    
    
    void Start()
    {
        symbolDrawing = FindObjectOfType<SymbolDrawing>();
        damageText.text = "";
        damageType.text = "";

    }

    public void CalculateDamage()
    {
        if (symbolDrawing.gestureResult.Score <= 0.75f)
        {
            okDamage = Random.Range(70, 76);
            damageType.text = "OK spell";
            damageText.text = "Damage Dealt: " + okDamage;
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.76f && symbolDrawing.gestureResult.Score <= 0.85f)
        {
            goodDamage = Random.Range(76, 86);
            damageType.text = "Good spell";
            damageText.text = "Damage Dealt: " + goodDamage;
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.86f && symbolDrawing.gestureResult.Score <= 0.94f)
        {
            greatDamage = Random.Range(86, 95);
            damageType.text = "Great spell!";
            damageText.text = "Damage Dealt: " + greatDamage;
        }
        
        else if (symbolDrawing.gestureResult.Score >= 0.95f)
        {
            amazingDamage = Random.Range(95, 101);
            damageType.text = "Amazing spell!";
            damageText.text = "Damage Dealt: " + amazingDamage;
        }
    }

    public void SpellFailed()
    {
        damageText.text = "";
        damageType.text = "";
    }
}
