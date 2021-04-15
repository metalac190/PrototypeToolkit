﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SoundSystem
{
    [CreateAssetMenu(menuName = "SoundSystem/Music Event", fileName = "MUS_")]
    public class MusicEvent : ScriptableObject
    {
        [Header("General Settings")]
        [SerializeField] AudioClip[] _musicLayers = null;
        [Tooltip("If true, layers will be added together, " +
            "otherwise each layer will player independently")]
        [SerializeField] bool _additiveLayers = true;
        [SerializeField] AudioMixerGroup _mixer;

        public AudioClip[] MusicLayers => _musicLayers;
        public bool AdditiveLayers => _additiveLayers;
        public AudioMixerGroup Mixer => _mixer;

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
