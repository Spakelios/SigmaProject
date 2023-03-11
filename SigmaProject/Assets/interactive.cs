using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactive : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> stuffToDo;
    public List<string> whatToSend;
    public void onInteract()
    {
        for(int i = 0; i<stuffToDo.Count; i++)
        {
            stuffToDo[i].SendMessage(whatToSend[i]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.SendMessage("setObject", gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("removeObject");
        }
    }
}
