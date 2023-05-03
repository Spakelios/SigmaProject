using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritess : MonoBehaviour
{
    public Sprite girl, boy;
    void Update()
    {
        if (SelectGender.female)
        {
            GetComponent<SpriteRenderer>().sprite = girl;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = boy;
        }
    }
}
