using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStorage : MonoBehaviour
{
    SkinnedMeshRenderer _skinnedMeshRenderer;
    private void Awake() => _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    [SerializeField] float _duration;
    public IEnumerator OpenGate()
    {
        GameManager.Instance.CameraController.ActivateCamera(CameraStrings.FourthCamera);

        for (float i = 0; i < _duration; i += Time.deltaTime)
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(0, (i / _duration) * 100);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        GameManager.Instance.SceneLoader.FadedLoadScene(1);
    }
}
