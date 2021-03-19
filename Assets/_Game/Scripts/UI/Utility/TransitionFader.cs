using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class TransitionFader : MonoBehaviour
{
    [SerializeField][Range(0, 1)]
    protected float _solidAlpha = 1f;
    [SerializeField][Range(0, 1)]
    protected float _clearAlpha = 0;
    [SerializeField] private float _fadeOnDuration = 2f;
    [SerializeField] private float _fadeOffDuration = 2f;
    [SerializeField] private float _lifeTime = 1f;
    [SerializeField] private float _delay = 0.3f;
    [SerializeField] private CanvasGroup _canvasGroup;

    public float FadeOnDuration => _fadeOnDuration;
    public float FadeOffDuration => _fadeOffDuration;
    public float Delay => _delay;

    protected void Awake()
    {
        // don't destroy, travels between scenes for transition
        transform.SetParent(null);
        Object.DontDestroyOnLoad(gameObject);

        float lifetimeMin = FadeOnDuration + FadeOffDuration + _delay;
        _lifeTime = Mathf.Clamp(_lifeTime, lifetimeMin, 10f);
    }

    private IEnumerator PlayRoutine()
    {
        // start at 0 opacity with delay
        _canvasGroup.alpha = 0;
        yield return new WaitForSeconds(_delay);

        // start fading in
        //TODO FadeOn();
        _canvasGroup.alpha = 1;
        // wait while fully opaque
        float onTime = _lifeTime - (FadeOffDuration + _delay);
        yield return new WaitForSeconds(onTime);

        // fade out and destroy
        //TODO FadeOff();
        _canvasGroup.alpha = 0;

        Destroy(gameObject, FadeOffDuration);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    public static void PlayTransition(TransitionFader transitionFaderPrefab)
    {
        if(transitionFaderPrefab != null)
        {
            TransitionFader instance = Instantiate
                (transitionFaderPrefab, Vector3.zero, Quaternion.identity);
            instance.Play();
        }
    }
}
