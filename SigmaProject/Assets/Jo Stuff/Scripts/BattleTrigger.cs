using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{

    public BattleSystem battleSystem;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        battleSystem.enabled = true;
        //battleSystem.enemy = gameObject.transform.parent.gameObject;
    }
}
