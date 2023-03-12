using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public static EnemyCheck instance;

    public GameObject fireEnemy;
    public GameObject waterEnemy;
    public GameObject mossEnemy;

    public static bool fireEnemyDead;
    public static bool waterEnemyDead;
    public static bool mossEnemyDead;
    


    private void Awake()
    {
        instance = this;
        
        if (fireEnemyDead)
        {
            fireEnemy.SetActive(false);
            //fireEnemyDead = false;
        }
        
        else if (waterEnemyDead)
        {
            waterEnemy.SetActive(false);
            //waterEnemyDead = false;
        }
        
        else if (mossEnemyDead)
        {
            mossEnemy.SetActive(false);
            //mossEnemyDead = false;
        }
    }

}
