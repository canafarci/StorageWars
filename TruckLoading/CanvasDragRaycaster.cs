using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDragRaycaster : MonoBehaviour
{
    [SerializeField] GameObject _draggingPlane;
    [SerializeField] LayerMask _dragLayer, _dropLayer;
    [SerializeField] float _lerpSpeed;


    bool _isDragging;
    GameObject _dragObject;
    Transform _targetTransform;


     void Update()
    {
        if (!_isDragging) { return; }

        DraggingBehaviour();

        if (Input.GetMouseButtonUp(0))
            EndRaycast();
    }
    public void StartRaycast(Transform targetTransform, GameObject objectToDrag)
    {
        _targetTransform = targetTransform;
        AlignDraggingPlane(targetTransform.position);
        _isDragging = true;
        _dragObject = Instantiate(objectToDrag, objectToDrag.transform.position, objectToDrag.transform.rotation);
    }

    private void DraggingBehaviour()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _dragLayer))
        {
            _dragObject.transform.position = Vector3.Lerp(_dragObject.transform.position, hit.point, Time.deltaTime * _lerpSpeed);

            float distance = Vector3.Distance(_dragObject.transform.position, _targetTransform.position);
            TruckLoadingTarget target = _targetTransform.GetComponent<TruckLoadingTarget>();

            if (distance < 5f)
            {
                target.ColorLerp(distance, 5f);
            }
        }
    }

    private void EndRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _dropLayer))
        {
            _dragObject.transform.position = _targetTransform.position;
            _dragObject.transform.GetComponent<IDraggable>().OnDragEnd();
            TruckLoadingTarget target = _targetTransform.GetComponent<TruckLoadingTarget>();
            target.OnDragSuccessful();

        }
        else
        {
            print("failed");
            Destroy(_dragObject);

        }

        _dragObject = null;
        _isDragging = false;
        _targetTransform.gameObject.SetActive(false);
        _targetTransform = null;
    }


    private void AlignDraggingPlane(Vector3 targetPosition)
    {
        _draggingPlane.transform.position = targetPosition;
    }
}
