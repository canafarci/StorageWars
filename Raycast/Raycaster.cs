using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] protected LayerMask _startLayerMask;
    protected virtual void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            StartRaycast(ray);
    }

    protected virtual void StartRaycast(Ray ray)
    {
        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _startLayerMask))
        {
            hit.transform.GetComponent<IRaycastable>().OnRaycast();
        }
        
    }
}
