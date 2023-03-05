using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HubWorldCameraController : MonoBehaviour
{
    public walk walk;
    public GameObject Cam1, Cam2;
    public GameObject canvas1;
    public GameObject tutorial1;
    

    public GameObject bookStack;
    public SpriteRenderer dark;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            // Cam3.SetActive(false);

            canvas1.SetActive(false);
            // canvas2.SetActive(false);
            StartCoroutine(LightsOn());
        }
    }

    public Animator anim;
    public IEnumerator LightsOn()
    {
        yield return new WaitForSeconds(3);
        
            anim.Play("look");
            bookStack.SetActive(true);

            yield return new WaitForSeconds(2);

            tutorial1.SetActive(true);
            walk.speed = 20;
            // dark.color = new Color(1f, 1f, 1f, .02f);

    }
}