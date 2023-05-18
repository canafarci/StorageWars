using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{
    private LayerMask _mask;
    bool _isInChestLayer;

    private void Awake()
    {
        _mask = gameObject.layer;
    }

    public void ChangeLayers()
    {
        if (_isInChestLayer)
            gameObject.layer = _mask;
        else
            gameObject.layer = LayerMask.NameToLayer("Chest");

        _isInChestLayer = !_isInChestLayer;
    }
}
