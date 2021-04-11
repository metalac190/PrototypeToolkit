using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class MusicPlayer : MonoBehaviour
    {
        // each source will correspond to a layer, and we'll control them together
        List<AudioSource> _layerSources = new List<AudioSource>();
        // this gives us control over AudioSource volumes for better fading
        List<float> _sourceStartVolumes = new List<float>();

        Coroutine _fadeVolumeRoutine = null;
        Coroutine _stopRoutine = null;

        bool _isStopping = false;
        public bool IsStopping => _isStopping;

        MusicManager _musicManager;

        private void Awake()
        {
            _musicManager = MusicManager.Instance;
            CreateLayerSources();
        }

        void CreateLayerSources()
        {
            for (int i = 0; i < MusicManager.MaxLayers; i++)
            {
                Debug.Log("Layer Index: " + i);
                _layerSources.Add(gameObject.AddComponent<AudioSource>());
                //_layerSources[i] = gameObject.AddComponent<AudioSource>();
                _layerSources[i].playOnAwake = false;
                _layerSources[i].loop = true;
            }
        }

        public void Play(MusicEvent musicEvent, float fadeTime)
        {
            Debug.Log("Play");
            for (int i = 0; i < _layerSources.Count; i++)
            {
                _layerSources[i].volume = 0;
                _layerSources[i].clip = musicEvent.MusicLayers[i];
                _layerSources[i].Play();
            }
            
            FadeVolume(_musicManager.Volume, fadeTime);
        }

        public void Stop(float fadeTime)
        {
            if (_stopRoutine != null)
                StopCoroutine(_stopRoutine);
            _stopRoutine = StartCoroutine(StopRoutine(fadeTime));
        }

        public void FadeVolume(float targetVolume, float fadeTime)
        {
            targetVolume = Mathf.Clamp(targetVolume, 0, 1);
            if (fadeTime < 0) fadeTime = 0;

            if (_fadeVolumeRoutine != null)
                StopCoroutine(_fadeVolumeRoutine);
            _fadeVolumeRoutine = StartCoroutine
                (FadeVolumeRoutine(targetVolume, fadeTime));
        }

        private IEnumerator StopRoutine(float fadeTime)
        {
            _isStopping = true;
            // start the fadeout
            // when done fading out, disable all sources
            if (_fadeVolumeRoutine != null)
                StopCoroutine(_fadeVolumeRoutine);
            _fadeVolumeRoutine = StartCoroutine(FadeVolumeRoutine(0, fadeTime));
            // wait for volume fade to finish
            yield return _fadeVolumeRoutine;

            foreach(AudioSource source in _layerSources)
            {
                source.Stop();
            }
            _isStopping = false;
        }

        private IEnumerator FadeVolumeRoutine(float targetVolume, float fadeTime)
        {
            SaveSourceStartVolumes();

            // fade audiosource volumes from their starting points
            for (float elapsedTime = 0; elapsedTime <= fadeTime; elapsedTime += Time.deltaTime)
            {
                float newVolume = 0;
                float startVolume = 0;
                // set one source volume at a time
                for (int i = 0; i < _layerSources.Count; i++)
                {
                    // if it's active fade it to target
                    if(i <= _musicManager.ActiveLayerIndex)
                    {
                        // fade the volume
                        startVolume = _sourceStartVolumes[i];
                        newVolume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / fadeTime);
                        _layerSources[i].volume = newVolume;
                        Debug.Log("AudioSource: " + i + " | volume: " + newVolume);
                    }
                    // otherwise fade it to 0
                    else
                    {
                        startVolume = _sourceStartVolumes[i];
                        newVolume = Mathf.Lerp(startVolume, 0, elapsedTime / fadeTime);
                        _layerSources[i].volume = newVolume;
                        Debug.Log("AudioSource: " + i + " | volume: " + newVolume);
                    }
                }

                yield return null;
            }

            // ensure final volume is set precisely before leaving
            for (int i = 0; i <= _musicManager.ActiveLayerIndex; i++)
            {
                if (i <= _musicManager.ActiveLayerIndex)
                {
                    _layerSources[i].volume = targetVolume;
                    Debug.Log("AudioSource: " + i + " | volume: " + _layerSources[i].volume);
                }
                // otherwise fade it to 0
                else
                {
                    _layerSources[i].volume = 0;
                    Debug.Log("AudioSource: " + i + " | volume: " + _layerSources[i].volume);
                }
            }
        }

        private void SaveSourceStartVolumes()
        {
            // store source start volumes independently for individual ASource lerping
            _sourceStartVolumes.Clear();
            for (int i = 0; i < _layerSources.Count; i++)
            {
                _sourceStartVolumes.Add(_layerSources[i].volume);
            }
        }
    }
}

