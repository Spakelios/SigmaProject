using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCondition : MonoBehaviour
{
    public GameObject ActivateTrigger;
    Collider2D col;
    SpriteRenderer spr;
    public GameObject pedestal;
    private void Start()
    {
        col = gameObject.GetComponent<CircleCollider2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ActivateTrigger.activeInHierarchy == false)
        {
            pedestal.GetComponent<Animator>().SetBool("isopen", true);
            spr.enabled = true;
            col.enabled = true;   
        }
    }
}
