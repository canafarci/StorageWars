using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DelayedDisableTargetGroup : MonoBehaviour
{
    CinemachineVirtualCamera _cam;

    private void Awake()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        StartCoroutine(DisableTargetGroup());
    }
    IEnumerator DisableTargetGroup()
    {
        yield return new WaitForSeconds(1f);
        _cam.AddCinemachineComponent<CinemachineComposer>();
        _cam.m_Follow = null;
        _cam.m_LookAt = null;
    }
}
