using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
  public GameObject Cam1, Cam2;
  
  
  private void OnTriggerStay2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      Cam1.SetActive(false);
      Cam2.SetActive(true);
    }
  }
  
  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      Cam1.SetActive(true);
      Cam2.SetActive(false);
    }
  }
}
