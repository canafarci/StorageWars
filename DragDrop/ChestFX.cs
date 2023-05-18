using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestFX : MonoBehaviour
{

    [SerializeField] Animator _childAnimator;
    [SerializeField] string _cameraName;
    [SerializeField] GameObject[] _FXs;
    [SerializeField] GameObject _bottomCircle, _contextText;
    LayerChange[] _changeableLayerObjects;
    CameraLayerChange _cameraLayerChange;
    Animator _animator;


    private void Awake()
    {
        _cameraLayerChange = FindObjectOfType<CameraLayerChange>();
        _animator = GetComponent<Animator>();
        _changeableLayerObjects = GetComponentsInChildren<LayerChange>();
    }

    public void PlayFX()
    {
        StartCoroutine(FXRoutine());
    }

    IEnumerator FXRoutine()
    {
        GameManager.Instance.CameraController.ActivateCamera(_cameraName);
        _bottomCircle.SetActive(true);
        _cameraLayerChange.SwitchCameraMask();
        SwitchObjectLayers();

        yield return new WaitForSeconds(1f);

        transform.DOPunchRotation(new Vector3(2.5f, 5f, 2.5f), .5f, 10, 0.2f);

        yield return new WaitForSeconds(.2f);

        foreach (GameObject fx in _FXs)
        {
            fx.SetActive(true);
        }
        _animator.enabled = true;
        _childAnimator.enabled = true;

        yield return new WaitForSeconds(1.25f);

        _contextText.SetActive(true);

        yield return new WaitForSeconds(1f);

        GameManager.Instance.CameraController.ActivateCamera(CameraStrings.FirstCamera);
        _cameraLayerChange.SwitchCameraMask();
        _bottomCircle.SetActive(false);
        _contextText.SetActive(false);

        foreach (GameObject fx in _FXs)
        {
            fx.SetActive(false);
        }
        SwitchObjectLayers();
    }

    private void SwitchObjectLayers()
    {
        foreach (LayerChange layerChange in _changeableLayerObjects)
        {
            layerChange.ChangeLayers();
        }
    }
}
