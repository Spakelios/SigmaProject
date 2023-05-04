using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectNote : MonoBehaviour
{
    //public GameObject UIref;

    public static bool note1 = false;
    public static bool note2 = false;
    public static bool note3 = false;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //UIref.SetActive(true);

            if (gameObject.name == "Note 1")
            {
                note1 = true;
            }
            
            else if (gameObject.name == "Note 2")
            {
                note2 = true;
            }

            else
            {
                note3 = true;
            }
            
            gameObject.SetActive(false);
        }
    }
}
