using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationManager : MonoBehaviour
{

    Animator anim;
    float playerXvelocity;
    float playerYvelocity;
    Rigidbody2D rb;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerXvelocity = rb.velocity.x;
        playerYvelocity = rb.velocity.y;

        anim.SetFloat("xvelocity", playerXvelocity);
        anim.SetFloat("yvelocity", playerYvelocity);
    }

}
