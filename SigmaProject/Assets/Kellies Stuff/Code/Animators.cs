using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animators : MonoBehaviour
{
    public Animator anim;

public void ScrollHighlighter()
{
    anim.Play("New Animation");
}

public void ScrollUnlit()
    {
        anim.Play("ScrollDown");
    }

public void stay()
{
    anim.Play("Anim");
}

public void move()
{

}



}
