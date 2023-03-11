using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    // Start is called before the first frame updat

    public bool canInteract;
    public GameObject interactableObject = null;
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            interactableObject.SendMessage("onInteract");
        }
    }

    public void setObject(GameObject obj)
    {
        interactableObject = obj;
        canInteract = true;
    }

    public void removeObject()
    {
        canInteract = false;
        interactableObject = null;
    }
}
