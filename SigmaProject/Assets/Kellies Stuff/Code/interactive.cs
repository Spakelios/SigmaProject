using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactive : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> stuffToDo;
    public List<string> whatToSend;

    public List<GameObject> stuffToDoSpell;
    public List<string> whatToSendSpell;
    public spell NeededSpell;
    public enum spell
    {
        Fire,
        Water,
        Moss,
        none
    }
    public void onInteract()
    {
        if(stuffToDo.Count !=0)
        for(int i = 0; i<stuffToDo.Count; i++)
        {
            stuffToDo[i].SendMessage(whatToSend[i]);
        }
    }

    public void onSpellCast(string spellcast)
    {
        if(NeededSpell != spell.none)
        {
            if(NeededSpell.ToString() == spellcast)
            {
                for (int i = 0; i < stuffToDoSpell.Count; i++)
                {
                    stuffToDoSpell[i].SendMessage(whatToSendSpell[i]);
                }
            }
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
