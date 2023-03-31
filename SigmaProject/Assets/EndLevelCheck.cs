using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] notes = new GameObject[3];
    bool[] notecheck = new bool[3];

    void Start()
    {
        
    }
    private void Update()
    {
        print(notecheck[0]);
        print(notecheck[1]);
        print(notecheck[2]);
        if (notecheck[0] == true && notecheck[1] == true && notecheck[2] == true)
        {
            print("done");
            SceneManager.LoadScene("NoTutorialHubworld");
        }
    }

    // Update is called once per frame
    public void addnote(GameObject whichnote)
    {
        if (whichnote == notes[0])
            notecheck[0] = true;
        else if(whichnote == notes[1])
            notecheck[1] = true;
        else
            if (whichnote == notes[2])
            notecheck[2] = true;
       
    }
}
