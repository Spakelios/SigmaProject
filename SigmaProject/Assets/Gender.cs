using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gender : MonoBehaviour
{
    public bool changender;

    public void Update()
    {
        if (changender = true)
        {
            gameObject.GetComponent<Animator>().SetBool("iswoman", true);
        }
        else
            gameObject.GetComponent<Animator>().SetBool("iswoman", false);
    }
    

public void changegender(bool check)
{
    changender = check;
}



}
