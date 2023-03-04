using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
 public GameObject tutorial, tutorial2;
 public Animator anim;
 private bool showBooks = false;

 public void OnTriggerStay2D(Collider2D other)
 {
  tutorial.SetActive(true);
  tutorial2.SetActive(false);
  showBooks = true;
 }

 public void OnTriggerExit2D(Collider2D other)
 {
  tutorial.SetActive(false);
  tutorial2.SetActive(false);
  showBooks = false;
 }

 public void Update()
 {
  if (showBooks && Input.GetKeyDown(KeyCode.F))
  {
   anim.Play("Books");
  }
 }
}
