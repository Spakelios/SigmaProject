using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;

public class HubWorldCameraController : MonoBehaviour
{
    public walk walk, walk2;
    public GameObject Cam1, Cam2, player;
    public GameObject canvas1;
    public GameObject tutorial1;
    
    public GameObject bookStack;
    public GameObject dataText;
    public GameObject Player, player2;

    public AudioSource menuMusic;
    public AudioSource hubMusic;
    
    
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            canvas1.SetActive(false);
            
            // canvas2.SetActive(false);
            walk.canMove = false;
            walk2.canMove = false;
            
            menuMusic.Stop();
            StartCoroutine(LightsOn());
        }
    }

    public Animator anim;
    
    public IEnumerator LightsOn()
    {
        player2.SetActive(false);
        Player.SetActive(false);
        yield return new WaitForSeconds(3);
        
        bookStack.SetActive(true);

        yield return new WaitForSeconds(2);
        
        
        tutorial1.SetActive(true); 
        dataText.SetActive(true);
        walk.canMove = true;
        walk2.canMove = true;
        

        if (!hubMusic.isPlaying)
        {
            hubMusic.Play();
        }

        yield return new WaitForSeconds(3f);
            
        dataText.SetActive(false);

    }
}
