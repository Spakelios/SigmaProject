using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBookController : MonoBehaviour
{
    [Header("Fame")]public Sprite page1, page2, page3;
    [Header("BaseBooks")]public GameObject BaseBook, baseBook2, baseBook3;

    public void Update()
    {
        if (Bookkeeper.book1)
        {
            BaseBook.GetComponent<Image>().sprite = page1;
            baseBook2.GetComponent<Image>().sprite = page2;
            baseBook3.GetComponent<Image>().sprite = page3;
        }
  
    }
}
