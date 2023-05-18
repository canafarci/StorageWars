using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDisableObject : MonoBehaviour
{
    private void OnEnable()
    {
        GameStart.OnGameStart += OnGameStart;
    }

    private void OnDisable()
    {
        GameStart.OnGameStart -= OnGameStart;
    }

    private void OnGameStart()
    {
        this.gameObject.SetActive(false);
    }

    
}
