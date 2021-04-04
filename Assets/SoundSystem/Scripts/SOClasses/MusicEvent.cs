using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    [CreateAssetMenu(menuName = "Audio/Music Event", fileName = "MUS_")]
    public class MusicEvent : ScriptableObject
    {
        [Header("General Settings")]
        [SerializeField] AudioClip[] _musicLayers = null;

        public AudioClip[] MusicLayers => _musicLayers;

        // add STEM support later

        public void Play(float fadeTime)
        {
            if (_musicLayers == null)
            {
                Debug.LogWarning("MusicEvent.Play(): No musicClip specified");
                return;
            }

            MusicManager.Instance.PlayMusic(this, fadeTime);
        }
    }


}
