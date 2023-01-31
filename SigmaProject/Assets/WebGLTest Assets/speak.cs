using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speak : MonoBehaviour
{
    public GameObject textbox;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
textbox.SetActive(true);
        }
    }
}
