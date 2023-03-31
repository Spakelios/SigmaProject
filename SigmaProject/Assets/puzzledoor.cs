using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzledoor : MonoBehaviour
{
    public List<GameObject> puzzlestuff;
    public List<bool> checks;
    public bool test;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < puzzlestuff.Count; i++)
            checks.Add(false);
    }
    private void Update()
    {
        if (test == true)
            getbool(null);
    }

    // Update is called once per frame
    void getbool(GameObject response)
    {
        int finalcheck = 0;
       for(int i = 0; i<puzzlestuff.Count; i++)
        {
            if (response == puzzlestuff[i])
            checks[i] = true;

        }
        for (int i = 0; i < checks.Count; i++)
        {
            if (checks[i] == true)
                finalcheck++;
        }
        if (finalcheck == checks.Count )
        {
             
            gameObject.SetActive(false) ;
        }
    }
}
