using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLerper : MonoBehaviour
{
    [SerializeField] Transform _lerpTarget;
    float _duration = 0.35f;
    public IEnumerator LerpTransform()
    {
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;
        Vector3 startScale = transform.localScale;

        for (float i = 0; i < _duration; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPosition, _lerpTarget.transform.position, i / _duration);
            transform.rotation = Quaternion.Lerp(startRotation, _lerpTarget.rotation, i / _duration);
            transform.localScale = Vector3.Lerp(startScale, _lerpTarget.localScale, i / _duration);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
