using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject helpScreen;
    public void start()
    {
        SceneManager.LoadScene("empty");
    }
    
    public void help()
    {
        helpScreen.SetActive(true);
    }

    public void closeHelp()
    {
        helpScreen.SetActive(false);
    }
}
