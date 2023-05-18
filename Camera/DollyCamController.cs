using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class DollyCamController : MonoBehaviour
{
    [SerializeField] float _dollyDuration;
    float _currentDuration;
    CinemachineVirtualCamera _cam;
    CinemachineTrackedDolly _trackedDolly;

    public static event Action OnDollyFinished;
    private void Awake()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
        _trackedDolly = _cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        _currentDuration = _dollyDuration;
    }
    private void OnEnable() => StartCoroutine(DollyCamera());
    IEnumerator DollyCamera()
    {
        while (_currentDuration > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            _currentDuration -= Time.deltaTime;
            _trackedDolly.m_PathPosition = ((_dollyDuration - _currentDuration) / _dollyDuration);
        }

        
        OnDollyFinished?.Invoke();
    }
}
