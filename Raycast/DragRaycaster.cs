using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRaycaster : Raycaster
{
    [SerializeField] LayerMask _dropLayer, _dragLayer;
    [SerializeField] Transform _box1Transform, _box3Transform;
    [SerializeField] float _lerpSpeed, _verticalTargetValue;

    bool _isDragging;
    GameObject _colliderObject, _dragObject;
    Vector3 _startPosition;

    protected override void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        base.Update();

        if (_isDragging)
            DraggingBehaviour(ray);

        if (Input.GetMouseButtonUp(0))
            EndDragging(ray);
    }

    protected override void StartRaycast(Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _startLayerMask))
        {
            bool dragRaycast =  hit.transform.GetComponent<IRaycastable>().OnRaycast();

            if (dragRaycast)
            {
                AudioConfig audioConfig = GameManager.Instance.References.GameConfig.DragStartConfig;
                GameManager.Instance.AudioManager.PlaySFX(audioConfig.Audio, audioConfig.Volume);

                _dragObject = hit.transform.gameObject;
                _startPosition = _dragObject.transform.position;
                _isDragging = true;
                _colliderObject = GenerateDraggingPlane(hit.point);
            }
            else
            {
                AudioConfig audioConfig = GameManager.Instance.References.GameConfig.ChestConfig;
                GameManager.Instance.AudioManager.PlaySFX(audioConfig.Audio, audioConfig.Volume);
                return;
            }
            
        }
    }

    private void DraggingBehaviour(Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _dragLayer))
        {
            _dragObject.transform.position = Vector3.Lerp(_dragObject.transform.position, hit.point, Time.deltaTime * _lerpSpeed);
        }
    }

    private void EndDragging(Ray ray)
    {
        RaycastHit hit;

        if (_dragObject == null) { return; }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _dropLayer))
        {
            hit.transform.gameObject.GetComponent<IDropTarget>().OnDrop();
            _dragObject.gameObject.GetComponent<IDraggable>().OnDragEnd(hit.transform.position);
        }
        else
        {
            if (_dragObject != null)
                _dragObject.transform.position = _startPosition;
        }

        _dragObject = null;
        _isDragging = false;
        Destroy(_colliderObject);
        _colliderObject = null;
    }

    private GameObject GenerateDraggingPlane(Vector3 position, bool isAligned = true)
    {
        GameObject colliderObject = new GameObject();
        colliderObject.transform.position = position;
        colliderObject.transform.localScale = new Vector3(20f, 20f, 0.05f);

        colliderObject.AddComponent<BoxCollider>();
        colliderObject.GetComponent<BoxCollider>().isTrigger = true;
        colliderObject.layer = LayerMask.NameToLayer("DragPlane");
        if (isAligned)
            colliderObject.transform.rotation = Quaternion.FromToRotation(transform.forward, CalculateNormal(position)) * transform.rotation;
        return colliderObject;
    }

    private Vector3 CalculateNormal(Vector3 raycastOrigin)
    {
        Vector3 side1, side2;
        if (raycastOrigin.y > _verticalTargetValue)
        {
            Vector3 box1offset = _box1Transform.position;
            box1offset.y = _verticalTargetValue;
            Vector3 box3offset = _box3Transform.position;
            box3offset.y = _verticalTargetValue;
            side1 = box1offset - raycastOrigin;
            side2 = box3offset - raycastOrigin;
        }
        else
        {
            raycastOrigin.y = _verticalTargetValue;
            Vector3 box1offset = _box1Transform.position;
            box1offset.y = _verticalTargetValue;
            Vector3 box3offset = _box3Transform.position;
            box3offset.y = _verticalTargetValue;
            side1 = box1offset - raycastOrigin;
            side2 = box3offset - raycastOrigin;
        }
        
        return Vector3.Cross(side1, side2);
    }
}
