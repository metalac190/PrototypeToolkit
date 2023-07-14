using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Uses the screen fader as a 'flash' screen effect. Extremely useful for damage/healing
/// etc. or any other effect where you want screen emphasis
/// </summary>
public class ColorFlasher : MonoBehaviour
{
    public event Action FlashCompleted = delegate { };

    [Header("Color Flasher")]
    [SerializeField] Image _flashImage = null;
    [SerializeField] Canvas _canvas = null;
    [SerializeField] Color _flashColor;
    [SerializeField] bool _isLooping = false;
    [Header("Durations")]
    [SerializeField] float _flashInTime = .3f;
    [SerializeField] float _flashHoldTime = 0;
    [SerializeField] float _flashOutTime = .3f;
    [Header("Alpha")]
    [Range(0, 1)] [SerializeField] float _alphaMin = 0;
    [Range(0,1)] [SerializeField] float _alphaMax = 1;

    Coroutine _flashRoutine = null;

    private void Awake()
    {
        _flashImage.color = _flashColor;

        SetAlphaToZero();
        _canvas.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopFlash();
    }

    public void Flash()
    {
        _canvas.gameObject.SetActive(true);

        if (_flashRoutine != null)
            StopCoroutine(_flashRoutine);
        _flashRoutine = StartCoroutine(FlashRoutine(_flashColor));
    }

    // allow us to send in custom colors, if needed
    public void Flash(Color flashColor)
    {
        _canvas.gameObject.SetActive(true);

        if (_flashRoutine != null)
            StopCoroutine(_flashRoutine);
        _flashRoutine = StartCoroutine(FlashRoutine(flashColor));
    }

    public void StopFlash()
    {
        if (_flashRoutine != null)
            StopCoroutine(_flashRoutine);
        SetAlphaToZero();
        // deactivate canvas for optimization
        _canvas.gameObject.SetActive(false);
    }

    private void SetAlphaToZero()
    {
        Color newColor = _flashImage.color;
        newColor.a = 0;
        _flashImage.color = newColor;
    }

    IEnumerator FlashRoutine(Color flashColor)
    {
        do
        {
            yield return FlashInRoutine(flashColor);
            yield return new WaitForSeconds(_flashHoldTime);
            yield return FlashOutRoutine(flashColor);

            FlashCompleted.Invoke();
        } while (_isLooping);
        StopFlash();
    }

    IEnumerator FlashInRoutine(Color flashColor)
    {
        Color newColor = flashColor;
        for (float elapsedTime = 0f; elapsedTime <= _flashInTime; elapsedTime += Time.deltaTime)
        {
            newColor.a = Mathf.Lerp(_alphaMin, _alphaMax, elapsedTime / _flashInTime);
            _flashImage.color = newColor;
            yield return null;
        }
        // set to max, just in case
        newColor.a = _alphaMax;
        _flashImage.color = newColor;
    }

    IEnumerator FlashOutRoutine(Color flashColor)
    {
        Color newColor = flashColor;
        for (float elapsedTime = 0f; elapsedTime <= _flashOutTime; elapsedTime += Time.deltaTime)
        {
            newColor.a = Mathf.Lerp(_alphaMax, _alphaMin, elapsedTime / _flashOutTime);
            _flashImage.color = newColor;
            yield return null;
        }
        // set to max, just in case
        newColor.a = 0;
        _flashImage.color = newColor;
    }
}
