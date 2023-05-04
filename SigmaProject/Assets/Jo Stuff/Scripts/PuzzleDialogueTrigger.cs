using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public PuzzleDialogueManager puzzleDialogue;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleDialogue.StartDialogue(dialogue);
        }
    }
}
