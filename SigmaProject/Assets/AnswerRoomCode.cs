using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerRoomCode : MonoBehaviour
{
    public GameObject answerUi;
    
    GameObject[] toggles = new GameObject[3];
    GameObject chosenanswer;
    public GameObject correctAnswer;
    public GameObject finish;
    // Start is called before the first frame update
    private void Start()
    {
        for(int i = 0; i<3; i++)
        {
            toggles[i] = answerUi.transform.GetChild(i + 1).gameObject;
        }
    }
    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (toggles[i].GetComponent<Toggle>().isOn)
                chosenanswer = toggles[i];
        }
        if (chosenanswer == correctAnswer)
        {
            finish.SendMessage("addnote", gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            answerUi.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            answerUi.SetActive(false);
        }

    }


}
