using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/MusicEvent", fileName = "MUS_")]
public class MusicEvent : ScriptableObject
{
    [Header("General Settings")]
    [SerializeField] AudioClip _musicClip = null;
    [SerializeField] float _fadeTime = 1;
    [SerializeField] bool _crossFade = false;

    // add STEM support later

    public void Play()
    {
        if (_musicClip == null) 
        {
            Debug.LogWarning("MusicEvent.Play(): No musicClip specified");
            return; 
        }
            
        // if no fade, don't worry about it
        if(_fadeTime <= 0)
        {
            MusicManager.Instance.PlayMusic(_musicClip);
        }
        // add a fade
        else
        {
            if(_crossFade == true)
            {
                MusicManager.Instance.PlayMusicWithFade(_musicClip, _fadeTime);
            }
            else
            {
                MusicManager.Instance.PlayMusicWithCrossFade(_musicClip, _fadeTime);
            }
        }
    }
}

