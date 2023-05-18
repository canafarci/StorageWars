using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    CanvasGroup _canvasGroup;
    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoad;
    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoad;
    private void Awake() => _canvasGroup = GameManager.Instance.References.CanvasGroup;
    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        if (FadeRoutine != null)
            StopCoroutine(FadeRoutine);

        FadeRoutine = StartCoroutine(FadeIn());
    }

    public Coroutine FadeRoutine;
    public IEnumerator FadeOut()
    {
        while (_canvasGroup.alpha < 1f)
        {
            yield return new WaitForSeconds(0.01f);
            _canvasGroup.alpha += 0.02f;
        }
    }

    public IEnumerator FadeIn()
    {
        while (_canvasGroup.alpha > 0f)
        {
            yield return new WaitForSeconds(0.01f);
            _canvasGroup.alpha -= 0.02f;
        }
    }
}
