using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Cinemachine;
using Cinemachine.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject Cam1, Cam2, BookPopUp, BookUI;
    public walk walk;
    public Animator anim, StoneAnim;
    
    
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
        CineMachineShake.Instance.ScreenShake(1.5f, 0.4f);
        StoneAnim.Play("MovingPath");

        yield return new WaitForSeconds(7f);

        CineMachineShake.Instance.ScreenShake(0,0);
        walk.speed = 10;
    }
}
