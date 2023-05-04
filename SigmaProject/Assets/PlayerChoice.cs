using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoice : MonoBehaviour
{
    public GameObject fem, boy;
    private void Update()
    {
        if (SelectGender.female && !SelectGender.male)
        {
            fem.SetActive(true);
        }
        if (!SelectGender.female && SelectGender.male)
        {
            boy.SetActive(true);
        }
    }

}
