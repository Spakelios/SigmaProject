using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placeNote : MonoBehaviour
{
    Toggle tg;
    Vector2 startpos;

    private void Start()
    {
        tg = gameObject.GetComponent<Toggle>();
        startpos = gameObject.transform.localPosition;
    }
    private void Update()
    {
        if (tg.isOn)
        {
            gameObject.transform.localPosition = new Vector2(-1.6f, 17.4f);
        }
        else
            gameObject.transform.localPosition = startpos;
    }
}
