using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EstimatedMoneyText : MonoBehaviour
{
    TextMeshProUGUI _text;
    float _currentValue;
    [SerializeField] ParticleSystem _vfx1, _vfx2;
    private void OnEnable() => DragDropObject.OnDropItem += OnDropItem;
    private void OnDisable() => DragDropObject.OnDropItem -= OnDropItem;

    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    private void OnDropItem(int value)
    {
        _currentValue += value;
        _text.text = _currentValue.ToString() + "$";
        
        _vfx1.Play();
        _vfx2.Play();
    }
}
