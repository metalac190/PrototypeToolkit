using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    [CreateAssetMenu(menuName = "Audio/Music Event", fileName = "MUS_")]
    public class MusicEvent : ScriptableObject
    {
        [Header("General Settings")]
        [SerializeField] AudioClip _musicClip = null;
        [SerializeField] float _fadeTime = 1;

        // add STEM support later

        public void Play()
        {
            if (_musicClip == null)
            {
                Debug.LogWarning("MusicEvent.Play(): No musicClip specified");
                return;
            }

            // if no fade, don't worry about it
            if (_fadeTime <= 0)
            {
                MusicManager.Instance.PlayMusic(_musicClip);
            }
            // add a fade
            else
            {
                MusicManager.Instance.PlayMusicWithCrossFade(_musicClip, _fadeTime);
            }
        }
    }


}
