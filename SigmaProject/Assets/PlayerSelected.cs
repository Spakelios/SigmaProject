using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelected : MonoBehaviour
{
 public Animator Fem, Male;
 public GameObject femal, mal;
 public void Options()
 {
  if (!SelectGender.male && SelectGender.female)
  {
   Fem.Play("PlayerW_Start"); 
  }
  else
  {
   Male.Play("OptionsWalk");
  }
 }

 public void returnOptions()
 {
  if (!SelectGender.male && SelectGender.female)
  {
   Fem.Play("PlayerW_Return");
  }
  else
  {
   Male.Play("OptionsReturn");
  }
 }
 
 public void Play()
 {
  if (!SelectGender.male && SelectGender.female)
  {
   femal.SetActive(true);
   Fem.Play("WomanWalkIn");
  }
  else
  {
   mal.SetActive(true);
   Male.Play("PlayerStart");
  }
 }


}
