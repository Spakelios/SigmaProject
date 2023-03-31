using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnLight : MonoBehaviour
{
    public bool ison;
    public GameObject door;
    // Start is called before the first frame update
    public void turnOn()
    {
        door.SendMessage("getbool", gameObject);
        gameObject.GetComponent<Animator>().SetBool("islit", true);
    }
}
