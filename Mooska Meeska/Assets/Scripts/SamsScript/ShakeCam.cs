using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCam : MonoBehaviour
{
    public static ShakeCam Instance { get; private set; }

    private CinemachineVirtualCamera CVC;
    private float shakeTimer;

    private void Awake()
    {
        Instance = this;
        CVC = GetComponent<CinemachineVirtualCamera>();
    }
    public void ShakeCamera(float intesity, float time)
    {
        CinemachineBasicMultiChannelPerlin noise = CVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = intesity;
    }

    public void StopCamera()
    {
        CinemachineBasicMultiChannelPerlin noise = CVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0f;
    }

}
