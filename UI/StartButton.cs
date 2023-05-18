using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnGameStart()
    {
        GameManager.Instance.CameraController.ActivateCamera(CameraStrings.SecondCamera);
        this.gameObject.SetActive(false);
    }
}
