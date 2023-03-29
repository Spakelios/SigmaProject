using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    public void newGame()

    {
        GameManagement.SPAWN = 1;
        SceneManager.LoadScene("HubWorld2");
    }
}