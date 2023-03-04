using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public Animator anim;
    public GameObject button;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hi Player uwu");
            anim.Play("New Animation");
            button.SetActive(true);
        }
    }
}
