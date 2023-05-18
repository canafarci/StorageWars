using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DollyEndBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _objectToDisable;
    [SerializeField] GameObject[] _objectsToEnable;
    [SerializeField] Collider _collider;
    private void OnEnable() => DollyCamController.OnDollyFinished += OnDollyFinished;
    private void OnDisable() => DollyCamController.OnDollyFinished -= OnDollyFinished;

    private void OnDollyFinished()
    {
        GameManager.Instance.CameraController.ActivateCamera(CameraStrings.ThirdCamera);
        _objectToDisable.SetActive(false);

        foreach (GameObject go in _objectsToEnable)
        {
            go.SetActive(true);
        }

        _collider.enabled = true;
    }
}
