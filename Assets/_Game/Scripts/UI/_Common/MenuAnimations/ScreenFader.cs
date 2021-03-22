using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// This script will flash a UI Image component with the given parameters.
/// This is intended to be a fairly generic script, working off of a lot of parameters. This will
/// allow it to be used in multiple different systems - screen fades, powerup flashes, transitions, etc.
/// Created by: Adam Chandler
/// </summary>

public class ScreenFader : MonoBehaviour
{
    public event Action FadeInCompleted = delegate { };
    public event Action FadeOutCompleted = delegate { };
    public event Action FadeInOutCompleted = delegate { };

    #region INSPECTOR
    [Header("Screen Fader")]
    [SerializeField] CanvasGroup _canvasToFade;
    [SerializeField] bool _shouldBlockRaycasts = false;
    #endregion

    #region PRIVATE FIELDS
    Coroutine _fadeRoutine = null;
    #endregion

    protected virtual void Awake()
    {
        _canvasToFade.blocksRaycasts = _shouldBlockRaycasts;
        _canvasToFade.interactable = false;
        _canvasToFade.alpha = 0;
    }

    public void FadeInOut(float fadeInTime, float waitTimeWhileFullfloat, float fadeOutTime,
    float alphaMin, float alphaMax)
    {
        // clamp time values above 0
        if (fadeInTime <= 0)
            fadeInTime = 0;
        if (fadeOutTime < 0)
            fadeOutTime = 0;

        if (_fadeRoutine != null)
            StopCoroutine(_fadeRoutine);
        _fadeRoutine = StartCoroutine(FadeInOutRoutine(fadeInTime, waitTimeWhileFullfloat, fadeOutTime,
            alphaMin, alphaMax));
    }

    public void FadeIn(float fadeInTime, float alphaMin, float alphaMax)
    {
        if (_fadeRoutine != null)
            StopCoroutine(_fadeRoutine);
        _fadeRoutine = StartCoroutine(FadeInRoutine(fadeInTime, alphaMin, alphaMax));
    }

    public void FadeOut(float fadeOutTime, float alphaMin, float alphaMax)
    {
        if (_fadeRoutine != null)
            StopCoroutine(_fadeRoutine);
        _fadeRoutine = StartCoroutine(FadeOutRoutine(fadeOutTime, alphaMin, alphaMax));
    }

    public void StopCurrentFade()
    {
        if (_fadeRoutine != null)
            StopCoroutine(_fadeRoutine);
        _canvasToFade.alpha = 0;
    }

    IEnumerator FadeInOutRoutine(float fadeInTime, float waitTimeWhileFullfloat,
    float fadeOutTime, float alphaMin, float alphaMax)
    {
        yield return FadeInRoutine(fadeInTime, alphaMin, alphaMax);
        yield return new WaitForSeconds(waitTimeWhileFullfloat);
        yield return FadeOutRoutine(fadeOutTime, alphaMin, alphaMax);

        FadeInOutCompleted.Invoke();
    }

    IEnumerator FadeInRoutine(float fadeInTime, float minAlpha, float maxAlpha)
    {
        for (float elapsedTime = 0f; elapsedTime <= fadeInTime; elapsedTime += Time.deltaTime)
        {
            _canvasToFade.alpha = Mathf.Lerp(minAlpha, maxAlpha, elapsedTime / fadeInTime);
            yield return null;
        }
        _canvasToFade.alpha = maxAlpha;

        FadeInCompleted.Invoke();
    }

    IEnumerator FadeOutRoutine(float fadeOutTime, float alphaMin, float alphaMax)
    {
        // fade out
        for (float elapsedTime = 0f; elapsedTime <= fadeOutTime; elapsedTime += Time.deltaTime)
        {
            _canvasToFade.alpha = Mathf.Lerp(alphaMax, alphaMin, elapsedTime / fadeOutTime);
            yield return null;
        }
        _canvasToFade.alpha = alphaMin;

        FadeOutCompleted.Invoke();
    }
}
