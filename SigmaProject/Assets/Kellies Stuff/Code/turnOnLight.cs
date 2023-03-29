using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnLight : MonoBehaviour
{
    // Start is called before the first frame update
    public void turnOn()
    {
        gameObject.GetComponent<Animator>().SetBool("islit", true);
    }
}
