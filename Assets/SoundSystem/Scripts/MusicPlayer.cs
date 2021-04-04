using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class MusicPlayer : MonoBehaviour
    {
        // each source will correspond to a layer, and we'll control them together
        AudioSource[] _layerSources;
        int numOfLayers = 3;
        int _activeLayerIndex = 0;
        
        public int Volume { get; private set; }

        Coroutine _volumeFadeRoutine = null;
        Coroutine _stopRoutine = null;

        public int ActiveLayerIndex 
        {
            get => _activeLayerIndex;
            private set
            {
                value = Mathf.Clamp(value, 0, _layerSources.Length);
                _activeLayerIndex = value;
            }
        }

        private void Awake()
        {
            CreateLayerSources();
        }

        void CreateLayerSources()
        {
            int maxLayers = MusicManager.MaxLayers;
            for (int i = 0; i < maxLayers; i++)
            {
                _layerSources[i] = gameObject.AddComponent<AudioSource>();
            }
        }

        public void Play(MusicEvent musicEvent, float startVolume, float fadeTime)
        {
            for (int i = 0; i < _layerSources.Length; i++)
            {
                _layerSources[i].volume = 0;
                _layerSources[i].clip = musicEvent.MusicLayers[i];
                _layerSources[i].Play();
            }

            SetVolume(startVolume, fadeTime);
        }

        public void Stop(float fadeTime)
        {
            if (_stopRoutine != null)
                StopCoroutine(_stopRoutine);
            _stopRoutine = StartCoroutine(StopRoutine(fadeTime));
        }

        public void SetVolume(float newVolume, float fadeTime)
        {
            newVolume = Mathf.Clamp(newVolume, 0, 1);

            // if no fade time, set into layer sources
            if(fadeTime <= 0)
            {
                foreach (AudioSource source in _layerSources)
                {
                    source.volume = newVolume;
                }
                return;
            }
            // if there's fade time, do our fade routine
            else
            {
                if (_volumeFadeRoutine != null)
                    StopCoroutine(_volumeFadeRoutine);
                _volumeFadeRoutine = StartCoroutine
                    (VolumeFadeRoutine(newVolume, fadeTime));
            }
        }

        private IEnumerator StopRoutine(float fadeTime)
        {
            // start the fadeout
            // when done fading out, disable all sources
            yield return null;
        }

        private IEnumerator VolumeFadeRoutine(float targetVolume, float fadeTime)
        {
            yield return null;
        }
    }
}

