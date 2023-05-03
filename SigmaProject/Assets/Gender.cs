using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Gender : MonoBehaviour
{
    public bool changender;
  
    public void changegender(bool check)
    {
        changender = check;
    }
    
    public void Start()
    {
        if (changender = true)
        {
            gameObject.GetComponent<Animator>().SetBool("iswoman", true);
        }
        else
            gameObject.GetComponent<Animator>().SetBool("iswoman", false);
    }

}
