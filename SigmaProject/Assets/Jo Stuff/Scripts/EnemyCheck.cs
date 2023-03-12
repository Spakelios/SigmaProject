using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public static EnemyCheck instance;

    public GameObject fireEnemy;
    public GameObject waterEnemy;
    public GameObject mossEnemy;

    public static bool fireEnemyDead = false;
    public static bool waterEnemyDead = false;
    public static bool mossEnemyDead = false;
    


    private void Awake()
    {
        instance = this;
        
        if (fireEnemyDead)
        {
            fireEnemy.SetActive(false);
            //fireEnemyDead = false;
        }
        
        if (waterEnemyDead)
        {
            waterEnemy.SetActive(false);
            //waterEnemyDead = false;
        }
        
        if (mossEnemyDead)
        {
            mossEnemy.SetActive(false);
            //mossEnemyDead = false;
        }
    }

}
