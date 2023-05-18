using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropSceneController : MonoBehaviour
{
    int _boxesLeftToFill;
    [SerializeField] GameObject _FX;

    private void Awake()
    {
        foreach (var item in FindObjectsOfType<DropBox>())
        {
            _boxesLeftToFill++;
        }
    }
    private void OnEnable()
    {
        DropBox.OnBoxFilled += OnBoxFilled;
    }

    private void OnDisable()
    {
        DropBox.OnBoxFilled -= OnBoxFilled;
    }

    private void OnBoxFilled()
    {
        _boxesLeftToFill--;

        if (_boxesLeftToFill == 0)
        {
            GameManager.Instance.SceneLoader.FadedLoadScene(2, 2f);
            _FX.SetActive(true);
        }
    }
}
