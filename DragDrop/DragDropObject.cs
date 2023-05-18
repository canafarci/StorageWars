using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropObject : MonoBehaviour, IDraggable, IRaycastable, ITweener
{
    [SerializeField] int _estimatedValue;
    public static event Action<int> OnDropItem;
    public void OnDrag(Vector3 position)
    {
        // juice
    }

    public void OnDragEnd()
    {

    }

    public void OnDragEnd(Vector3 position)
    {
        OnDropItem?.Invoke(_estimatedValue);
        StartCoroutine(DropRoutine(position));
    }

    public bool OnRaycast()
    {
        StartCoroutine(RotationRoutine());
        return true;
    }

    public void Tween()
    {

    }

    protected virtual IEnumerator RotationRoutine()
    {
        print("called");
        transform.DOPunchRotation(new Vector3(12.5f, 12.5f, 25f), .5f, 10, 0.2f);
        yield return new WaitForSeconds(0.2f);

    }

    IEnumerator DropRoutine(Vector3 position)
    {
        transform.DOMove(position + new Vector3(0f, 0.5f, 0f), 0.2f);

        yield return new WaitForSeconds(0.2f);

        transform.DOPunchPosition(new Vector3(0f, 0.075f, 0f), 0.5f, 10, 1);
        yield return new WaitForSeconds(0.5f);

        transform.DOMove(position, 0.3f);
        transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);
    }
}
