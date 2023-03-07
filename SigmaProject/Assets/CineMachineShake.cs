using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Editor;

public class CineMachineShake : MonoBehaviour
{
    public static CineMachineShake Instance { get; private set; }
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    public float shakeTimer;

    public void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ScreenShake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    public void Update()
    {
        if (shakeTimer < 0)
        { 
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                //timer over
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

            }

        }
    }
}
