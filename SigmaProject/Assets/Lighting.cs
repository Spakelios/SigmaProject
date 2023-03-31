using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Lighting : MonoBehaviour
{
    
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Light2D GlobalLight;
    
    // Start is called before the first frame update
    public void AdjustLighting()
    {
        volumeSlider.value = GlobalLight.intensity;
    }

  // Update is called once per frame
    void Update()
    {
        
    }
}
