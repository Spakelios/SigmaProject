using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
   public GameObject page1, page2, page3;
   public GameObject spine;


   public void Page2Show()
   {
      page1.SetActive(false);
      page2.SetActive(true);
      page3.SetActive(false);
   }

   public void Page3Show()
   {
      page3.SetActive(true);
      page2.SetActive(false);
      page1.SetActive(false);
   }

   public void Page1Show()
   {
      page3.SetActive(false);
      page2.SetActive(false);
      page1.SetActive(true);
   }

   public void SpineBegone()
   {
      spine.SetActive(false);
   }

   public void SpineReturn()
   {
      spine.SetActive(true);
   }
}
