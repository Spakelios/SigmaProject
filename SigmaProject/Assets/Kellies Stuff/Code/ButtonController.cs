using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject Cam1, Cam2, player, text;
    
    public Animator anim;
    public GameObject popup;
    
    public void ActivateScroll()
    {

        anim.Play("Interactive");  

    }

    public void YesBut()
    {
        anim.Play("Interactive");
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        popup.SetActive(false);
        player.SetActive(false);
        text.SetActive(true);
       
    }

    public void NoBut()
    {
        anim.Play("ScrollDown");
        popup.SetActive(false);
    }
  
}
