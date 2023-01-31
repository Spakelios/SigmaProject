using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textScroller : MonoBehaviour
{
  public TextMeshProUGUI  text;
  public GameObject Textbox,roy;
 float texts= 0;
 
 public void ShowText()
  {
    text.text = "I hope my wife hasn't taken the kids yet";
    texts += 1;
  }

 public void Text()
  {
      if(texts >= 2)
      { 
          Destroy(Textbox); 
          Destroy(roy);
      }
  }
}

