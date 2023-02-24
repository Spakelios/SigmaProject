using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject Scrollbar;
    public Animator anim;
    public EventTrigger EventTrigger;
   
    
    public void ActivateScroll()
    {
        // Scrollbar.SetActive(true);
        // anim.Play("Interactive");
        
        if (Scrollbar.activeInHierarchy)
        {
            Scrollbar.SetActive(false);
            anim.Play("NonInteractive");
        }
        else
        {
            Scrollbar.SetActive(true);
            anim.Play("Interactive");
        }
    }

  
}
