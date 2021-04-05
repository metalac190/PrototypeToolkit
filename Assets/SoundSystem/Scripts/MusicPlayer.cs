using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class MusicPlayer : MonoBehaviour
    {
        // each source will correspond to a layer, and we'll control them together
        AudioSource[] _layerSources;
        int _activeLayerIndex = 0;
        
        public float Volume { get; private set; }

        Coroutine _fadeVolumeRoutine = null;
        Coroutine _stopRoutine = null;

        public int ActiveLayerIndex 
        {
            get => _activeLayerIndex;
            private set
            {
                value = Mathf.Clamp(value, 0, _layerSources.Length-1);
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
            // 
            Volume = 0;

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
            if (fadeTime < 0) fadeTime = 0;

            if (_fadeVolumeRoutine != null)
                StopCoroutine(_fadeVolumeRoutine);
            _fadeVolumeRoutine = StartCoroutine
                (FadeVolumeRoutine(newVolume, fadeTime));
        }

        private IEnumerator StopRoutine(float fadeTime)
        {
            // start the fadeout
            // when done fading out, disable all sources
            if (_fadeVolumeRoutine != null)
                StopCoroutine(_fadeVolumeRoutine);
            _fadeVolumeRoutine = StartCoroutine(FadeVolumeRoutine(0, fadeTime));
            yield return _fadeVolumeRoutine;

            foreach(AudioSource source in _layerSources)
            {
                source.Stop();
            }
        }

        private IEnumerator FadeVolumeRoutine(float targetVolume, float fadeTime)
        {
            float startingVolume = Volume;
            // fade volume
            for (float elapsedTime = 0; elapsedTime <= fadeTime; elapsedTime += Time.deltaTime)
            {
                // set new volume for each source, each game loop
                float newVolume = Mathf.Lerp(startingVolume, targetVolume, elapsedTime / fadeTime);
                for (int i = 0; i < ActiveLayerIndex; i++)
                {
                    _layerSources[i].volume = newVolume;
                }
                // save our new volume in case something interrupts this routine before the end
                Volume = newVolume;

                yield return null;
            }
            // ensure final volume is set precisely before leaving
            Volume = targetVolume;
        }
    }
}

