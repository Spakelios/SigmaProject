using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         Destroy(gameObject);
      }
   }
}