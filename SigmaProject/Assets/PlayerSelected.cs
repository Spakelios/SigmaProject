using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelected : MonoBehaviour
{
 public Animator Fem, Male;

 public void Options()
 {
  if (!SelectGender.male && SelectGender.female)
  {
   Fem.SetBool("options",true);
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
//
  }
  else
  {
   Male.Play("OptionsReturn");
  }
 }
}
