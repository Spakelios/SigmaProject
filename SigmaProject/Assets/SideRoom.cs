using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideRoom : MonoBehaviour
{
    public GameObject female, male;
    public void Update()
    {
        if (SelectGender.female && !SelectGender.male)
        {
            female.SetActive(true);
            male.SetActive(false);
        }
        if (!SelectGender.female && SelectGender.male)
        {
            male.SetActive(true);
            female.SetActive(false);
        }
    }
}
