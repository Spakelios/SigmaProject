using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInBooks : MonoBehaviour
{
    public GameObject UIref1;
    public GameObject UIref2;
    public GameObject UIref3;
    
    private void Update()
    {
        if (CollectNote.note1)
        {
            UIref1.SetActive(true);
        }

        if (CollectNote.note2)
        {
            UIref2.SetActive(true);
        }

        if (CollectNote.note3)
        {
            UIref3.SetActive(true); 
        }
    }
}
