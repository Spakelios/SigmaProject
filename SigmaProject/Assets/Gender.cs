using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gender : MonoBehaviour
{
    // Start is called before the first frame update
    public bool changender;
    private void Update()
    {
        
    }
    public void changegender(bool check)
    {
        if (check == true)
        {
            gameObject.GetComponent<Animator>().SetBool("iswoman", true);
        }
        else
            gameObject.GetComponent<Animator>().SetBool("iswoman", false);
    }
}
