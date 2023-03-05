using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject Cam1, Cam2, player, text, PB, BookPopUp, BookUI;
    public walk walk;
    public Animator anim, ShaderAnim, StoneAnim;
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
        StartCoroutine(ShaderAnimation());

    }

    public void NoBut()
    {
        anim.Play("ScrollDown");
        popup.SetActive(false);
    }

    IEnumerator ShaderAnimation()
    {
        ShaderAnim.Play("wo");

        yield return new WaitForSeconds(10f);
        
        ShaderAnim.StopPlayback();
    }

    public void show()
    {
        PB.SetActive(true);
        anim.Play("Interactive");
    }


    public void ChooseABook()
    {
        StartCoroutine(CAB());
    }

    private IEnumerator CAB()
    {
        walk.speed = 0;
        
        anim.Play("NoBooks");

        yield return new WaitForSeconds(10f);
        
        Cam2.SetActive(true);
        Cam1.SetActive(true);
        BookPopUp.SetActive(true);
        BookUI.SetActive(true);
        StoneAnim.Play("MovingPath");

        yield return new WaitForSeconds(7f);

        walk.speed = 10;
    }
}
