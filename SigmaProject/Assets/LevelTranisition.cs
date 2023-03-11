using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTranisition : MonoBehaviour
{
    public Animator anim;
    public float TranistionTime;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        anim.SetTrigger("StartTrigger");
        CineMachineShake.Instance.ScreenShake(1.5f, 0.4f);

        yield return new WaitForSeconds(TranistionTime);
        
        CineMachineShake.Instance.ScreenShake(0,0);
        SceneManager.LoadScene("gabScene");
    }
}
