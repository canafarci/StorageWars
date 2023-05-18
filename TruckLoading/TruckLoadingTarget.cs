using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckLoadingTarget : MonoBehaviour
{
    [HideInInspector] public Image _startDragImage;

    [SerializeField] GameObject _fX;
    TruckLoadingController _controller;
    Renderer[] _renderers;

    Color _defaultColor = new Color(0, 1, 0, 120f / 255f);
    Color _greenColor = new Color(1, 1, 1, 120f / 255f);

    private void Awake()
    {
        _controller = FindObjectOfType<TruckLoadingController>();
        _renderers = GetComponentsInChildren<Renderer>(true);
    }

    private void Start() => _controller.DragsLeft++;

    public void ColorLerp(float distance, float maxDistance)
    {
        foreach (Renderer renderer in _renderers)
        {
            Material objectMaterial = renderer.material;
            objectMaterial.color = Color.Lerp(_defaultColor, _greenColor, distance / maxDistance);
            renderer.sharedMaterial = objectMaterial;
        }
    }

    public void OnDragSuccessful()
    {
        _fX.SetActive(true);
        _startDragImage.gameObject.SetActive(false);
    }
}
