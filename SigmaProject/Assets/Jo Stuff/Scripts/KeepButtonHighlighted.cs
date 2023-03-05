using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeepButtonHighlighted : MonoBehaviour
{
    public Button fireButton;
    public Button waterButton;
    public Button mossButton;


    public void FireButtonActive()
    {
        fireButton.interactable = false;
        waterButton.interactable = true;
        mossButton.interactable = true;
    }

    public void WaterButtonActive()
    {
        fireButton.interactable = true;
        waterButton.interactable = false;
        mossButton.interactable = true;
    }

    public void MossButtonActive()
    {
        fireButton.interactable = true;
        waterButton.interactable = true;
        mossButton.interactable = false;
    }
}
