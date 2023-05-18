using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLayerChange : MonoBehaviour
{
    Camera cam;
    bool _isInDefaultLayer = true;


    private void Awake()
    {
        cam = Camera.main;
    }

    public void SwitchCameraMask()
    {
        if (_isInDefaultLayer)
            SwitchToChestLayer();
        else
            SwitchToDefaultLayer();
    }

    private void SwitchToChestLayer()
    {
        _isInDefaultLayer = false;
        cam.cullingMask = (1 << LayerMask.NameToLayer("Chest"));
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    private void SwitchToDefaultLayer()
    {
        _isInDefaultLayer = true;
        cam.cullingMask = -1;
        cam.clearFlags = CameraClearFlags.Skybox;
    }
}
