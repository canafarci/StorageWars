using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLerper : MonoBehaviour
{
    [SerializeField] Transform _targetTransform, _exitTransform;
    [SerializeField] float _time;

    public void LerpObjectIn(Transform lerpedObject) => StartCoroutine(LerpObject(lerpedObject, _targetTransform));
    public void LerpObjectOut(Transform lerpedObject) => StartCoroutine(LerpObject(lerpedObject, _exitTransform));
    IEnumerator LerpObject(Transform lerpedObject, Transform target)
    {
        Vector3 startPosition = lerpedObject.position;
        for (float i = 0; i < _time; i += Time.deltaTime)
        {
            lerpedObject.position = Vector3.Lerp(startPosition, target.transform.position, i / _time);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
