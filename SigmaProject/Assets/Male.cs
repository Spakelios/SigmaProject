using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Male : MonoBehaviour
{

 public PlayerStats playerStats;
 public GameObject malePlayer;
 public GameObject femalePlayer;
 
 
 public void male()
 {
  playerStats.playerGameObject = malePlayer;
  SelectGender.male = true;
 }

 public void Female()
 {
  playerStats.playerGameObject = femalePlayer;
  SelectGender.female = true;
 }
}
