using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateComponent : MonoBehaviour
{
    public GameObject refer;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            refer.SetActive(false);
        }
    }
}
