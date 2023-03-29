using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenewarp : MonoBehaviour
{
    public void swap()
    {
        SceneManager.LoadScene("HubWorld2");
    }
    
    public void underConstruction()
    {
        SceneManager.LoadScene("UNDERCONTRUCTION!");
    }
}
