using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject bookone, booktwo, bookthree, bookfour, bookfive, booksix, bookseven;


    public void Update()
    {
        if (Bookkeeper.book1)
        {
            bookone.SetActive(true);
            bookthree.SetActive(false);
            bookfive.SetActive(false);
            bookfour.SetActive(false);
            booktwo.SetActive(false);
            booksix.SetActive(false);
            bookseven.SetActive(false);
        }

        if (Bookkeeper.book2)
        {
            bookone.SetActive(false);
            bookthree.SetActive(false);
            bookfive.SetActive(false);
            bookfour.SetActive(false);
            booktwo.SetActive(true);
            booksix.SetActive(false);
            bookseven.SetActive(false);
        }

        if (Bookkeeper.book3)
        {
            bookone.SetActive(false);
            bookthree.SetActive(true);
            bookfive.SetActive(false);
            bookfour.SetActive(false);
            booktwo.SetActive(false);
            booksix.SetActive(false);
            bookseven.SetActive(false);
        }

        if (Bookkeeper.book4)
        {
            bookone.SetActive(false);
            bookthree.SetActive(false);
            bookfive.SetActive(false);
            bookfour.SetActive(true);
            booktwo.SetActive(false);
            booksix.SetActive(false);
            bookseven.SetActive(false);
        }

        if (Bookkeeper.book5)
        {
            bookone.SetActive(false);
            bookthree.SetActive(false);
            bookfive.SetActive(true);
            bookfour.SetActive(false);
            booktwo.SetActive(false);
            booksix.SetActive(false);
            bookseven.SetActive(false);
        }
        if (Bookkeeper.book6)
        {
            bookone.SetActive(false);
            bookthree.SetActive(false);
            bookfive.SetActive(false);
            bookfour.SetActive(false);
            booktwo.SetActive(false);
            booksix.SetActive(true);
            bookseven.SetActive(false);
        }
        
        if (Bookkeeper.book7)
        {
            bookone.SetActive(false);
            bookthree.SetActive(false);
            bookfive.SetActive(false);
            bookfour.SetActive(false);
            booktwo.SetActive(false);
            booksix.SetActive(false);
            bookseven.SetActive(true);
        }
    }


public void book1()
{
    Bookkeeper.book1 = true;
    Bookkeeper.book2 = false;
        Bookkeeper.book3 = false;
        Bookkeeper.book4 = false;
        Bookkeeper.book5 = false;
        Bookkeeper.book6 = false;
        Bookkeeper.book7 = false;
    }

    public void book2()
    {
        Bookkeeper.book1 = false;
        Bookkeeper.book2 = true;
        Bookkeeper.book3 = false;
        Bookkeeper.book4 = false;
        Bookkeeper.book5 = false;
        Bookkeeper.book6 = false;
        Bookkeeper.book7 = false;
        
    }
    public void book3()
    {
        Bookkeeper.book1 = false;
        Bookkeeper.book2 = false;
        Bookkeeper.book3 = true;
        Bookkeeper.book4 = false;
        Bookkeeper.book5 = false;
        Bookkeeper.book6 = false;
        Bookkeeper.book7 = false;
    }
    public void book4()
    {
        Bookkeeper.book1 = false;
        Bookkeeper.book2 = false;
        Bookkeeper.book3 = false;
        Bookkeeper.book4 = true;
        Bookkeeper.book5 = false;
        Bookkeeper.book6 = false;
        Bookkeeper.book7 = false;
    }
    public void book5()
    {
        Bookkeeper.book1 = false;
        Bookkeeper.book2 = false;
        Bookkeeper.book3 = false;
        Bookkeeper.book4 = false;
        Bookkeeper.book5 = true;
        Bookkeeper.book6 = false;
        Bookkeeper.book7 = false;
    }
   
    public void book6()
    {
        Bookkeeper.book1 = false;
        Bookkeeper.book2 = false;
        Bookkeeper.book3 = false;
        Bookkeeper.book4 = false;
        Bookkeeper.book5 = false;
        Bookkeeper.book6 = true;
        Bookkeeper.book7 = false;
    }    
    
    public void book7()
    {
        Bookkeeper.book1 = false;
        Bookkeeper.book2 = false;
        Bookkeeper.book3 = false;
        Bookkeeper.book4 = false;
        Bookkeeper.book5 = false;
        Bookkeeper.book6 = false;
        Bookkeeper.book7 = true;
    }
    
}
