using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject Cam1, Cam2, BookPopUp, BookUI;
    public walk walk;
    public Animator anim, StoneAnim;
    public AudioSource Bridge;
    
    
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
        Bridge.volume = 1;

        yield return new WaitForSeconds(10f);

        CineMachineShake.Instance.ScreenShake(0,0);
        walk.speed = 20;
        Bridge.volume = 0;
    }
}
