using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraEffects : MonoBehaviour
{
    #region Shake Settings

    [Header("Shake Settings")]
    [SerializeField] public float ShakeIntensity;
    [SerializeField] public float ShakeTime;
    private float timer;

    #endregion

    #region Follow Settings

    [Header("Follow Settings")]
    [SerializeField] public string Follow;
    private GameObject Player;

    #endregion

    #region Cinemachine Components

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    #endregion

    #region Initialization

    void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        Player = GameObject.FindGameObjectWithTag(Follow);
        if(Player != null){
            cinemachineVirtualCamera.Follow = Player.transform;
        }
        StopShake();
    }

    #endregion

    #region Update

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                StopShake();
            }
        }
    }

    #endregion

    #region Camera Shake

    public void ShakeCamera()
    {
        _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity;
        timer = ShakeTime;
    }

    public void StopShake()
    {
        _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }

    #endregion
}
