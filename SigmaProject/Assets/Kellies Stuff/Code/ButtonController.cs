using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject Cam1, Cam2, BookUI;
    public walk walk, walks;
    public Animator StoneAnim;
    public AudioSource Bridge;


    public void ChooseABook()
    {
        StartCoroutine(CAB());
    }

    private IEnumerator CAB()
    {
        walk.canMove = false;
        walks.canMove = false;

        yield return new WaitForSeconds(10f);
        
        Cam2.SetActive(true);
        Cam1.SetActive(true);
        BookUI.SetActive(true);
        CineMachineShake.Instance.ScreenShake(1.5f, 0.4f);
        StoneAnim.Play("MovingPath");
        Bridge.volume = 1;

        yield return new WaitForSeconds(9f);

        CineMachineShake.Instance.ScreenShake(0,0);
        walk.canMove = true;
        walks.canMove = true;
        Bridge.volume = 0;
        
    }
}
