using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : MonoBehaviour
{


    public GameObject guardEnemy;


    private void Start()
    {
        if (!guardEnemy.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
