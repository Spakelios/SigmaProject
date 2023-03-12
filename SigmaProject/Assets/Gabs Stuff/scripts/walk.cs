using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    float xMOV;
    float yMOV; 
    public float speed;
    Rigidbody2D rb;
    private Animator animator;
    public GameObject CurrentLayer;

    public bool canMove; //this bool is so I can stop the player from moving when the battle starts & they're in the battle scene
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        canMove = true;
        animator = gameObject.GetComponent<Animator>();
        animator.applyRootMotion = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMove) return;
        
        xMOV = Input.GetAxis("Horizontal") * speed * 0.1f;
        yMOV = Input.GetAxis("Vertical") * speed * 0.1f;
        /* if (xMOV != 0)
              gameObject.transform.position = new Vector3(gameObject.transform.position.x + xMOV, gameObject.transform.position.y, gameObject.transform.position.z);
          if (yMOV != 0)
              gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yMOV, gameObject.transform.position.z);
     */
        if (xMOV != 0 || yMOV != 0)
            rb.velocity = new Vector2(xMOV, yMOV);
        else
            rb.velocity = new Vector2(0, 0);
        
    }
}
