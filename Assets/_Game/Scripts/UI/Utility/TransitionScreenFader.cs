using UnityEngine;

/// <summary>
/// Use a transition fader for fading a color between scenes. This is handy for creating
/// more cinematic transitions. This Screen effect travels between scenes and destroys itself
/// on completion
/// </summary>
public class TransitionScreenFader : ScreenFader
{
    protected override void Awake()
    {
        base.Awake();
        // don't destroy, travels between scenes for transition
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        FadeInOutCompleted += OnFadeInOutCompleted;
    }

    private void OnDisable()
    {
        FadeInOutCompleted -= OnFadeInOutCompleted;
    }

    void OnFadeInOutCompleted()
    {
        Destroy(gameObject);
    }

    public void TransitionFade(float fadeInTime, float waitWhileFullTime, float fadeOutTime)
    {
        FadeInOut(fadeInTime, waitWhileFullTime, fadeOutTime, 0, 1);
    }

    public static void PlayTransition(TransitionScreenFader transitionFaderPrefab, 
        float fadeInTime, float waitWhileFullTime, float fadeOutTime)
    {
        if(transitionFaderPrefab != null)
        {
            TransitionScreenFader instance = Instantiate
                (transitionFaderPrefab, Vector3.zero, Quaternion.identity);
            instance.TransitionFade(fadeInTime, waitWhileFullTime, fadeOutTime);
        }
    }
}
