using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckLoadingDraggable : MonoBehaviour, ITweener, IDraggable
{
    TruckLoadingController _controller;

    private void Awake() => _controller = FindObjectOfType<TruckLoadingController>();

    public void OnDrag(Vector3 position)
    {
        //
    }

    public void OnDragEnd()
    {
        _controller.OnDragSuccessful();
        Tween();
    }

    public void Tween()
    {
        float targetScale = 0.15f;
        transform.DOPunchScale(new Vector3(targetScale, targetScale, targetScale), 0.75f, 5, 2f);
    }

    public void OnDragEnd(Vector3 position)
    {
        //
    }
}
