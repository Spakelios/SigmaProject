using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Male : MonoBehaviour
{
 public Animator m;
 public void male()
 {
  m.SetBool("is woman", false);
  SelectGender.male = true;
 }

 public void Female()
 {
  m.SetBool("is woman", true);
  SelectGender.female = true;
 }
}
