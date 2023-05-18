using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckLoadingController : MonoBehaviour
{
    public int DragsLeft;

    [SerializeField] GameObject _fx;

    public void OnDragSuccessful()
    {
        DragsLeft--;
        if (DragsLeft == 0)
            EndGame();
    }

    private void EndGame()
    {
        _fx.SetActive(true);
        GameManager.Instance.SceneLoader.FadedLoadScene(3, 2f);
    }
}
