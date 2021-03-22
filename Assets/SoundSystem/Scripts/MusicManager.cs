using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class MusicManager : SingletonMBPersistent<MusicManager>
    {
        // use 2 music sources so that we can do cross blending
        AudioSource _musicSource1 = null;
        AudioSource _musicSource2 = null;

        private bool _music1SourcePlaying = false;
        private Coroutine _musicBlendRoutine = null;

        private float _currentMusicVolume = .8f;
        public float CurrentMusicVolume
        {
            get => _currentMusicVolume;
            private set
            {
                value = Mathf.Clamp(value, 0, 1);
                _currentMusicVolume = value;
            }
        }
        public AudioSource ActiveSource => (_music1SourcePlaying) ? _musicSource1 : _musicSource2;
        public AudioSource InActiveSource => (_music1SourcePlaying) ? _musicSource2 : _musicSource1;

        #region MONOBEHAVIOUR
        protected override void Awake()
        {
            SetupMusicSources();
        }
        #endregion

        #region PUBLIC METHODS
        public void SetVolume(float newVolume)
        {
            CurrentMusicVolume = newVolume;
            ActiveSource.volume = CurrentMusicVolume;
        }

        public void FadeVolume(float targetVolume, float volumeBlendDuration)
        {
            if (_musicBlendRoutine != null)
                StopCoroutine(_musicBlendRoutine);

            _musicBlendRoutine = StartCoroutine(FadeMusicVolumeRoutine
                (ActiveSource, targetVolume, volumeBlendDuration));
        }

        public void PlayMusic(AudioClip musicClip)
        {
            // determine which source is active
            AudioSource activeSource = ActiveSource;

            activeSource.clip = musicClip;
            activeSource.volume = CurrentMusicVolume;
            activeSource.Play();
        }

        public void PlayMusicWithFade(AudioClip musicClip, float transitionDuration)
        {
            if (_musicBlendRoutine != null)
                StopCoroutine(_musicBlendRoutine);

            _musicBlendRoutine = StartCoroutine(FadeNewMusicRoutine
                (ActiveSource, musicClip, transitionDuration));
        }

        public void PlayMusicWithCrossFade(AudioClip musicClip, float transitionTime)
        {
            // swap the source
            _music1SourcePlaying = !_music1SourcePlaying;

            InActiveSource.clip = musicClip;
            InActiveSource.Play();

            if (_musicBlendRoutine != null)
                StopCoroutine(_musicBlendRoutine);
            _musicBlendRoutine = StartCoroutine(CrossfadeNewMusicRoutine
                (ActiveSource, InActiveSource, transitionTime));
        }
        #endregion

        private IEnumerator FadeMusicVolumeRoutine(AudioSource activeSource, float targetVolume, float fadeTime)
        {
            float startingVolume = CurrentMusicVolume;
            // fade volume
            for (float elapsedTime = 0; elapsedTime <= fadeTime; elapsedTime += Time.deltaTime)
            {
                float newVolume = Mathf.Lerp(startingVolume, targetVolume, elapsedTime / fadeTime);
                activeSource.volume = newVolume;
                yield return null;
            }
            CurrentMusicVolume = targetVolume;
        }

        private IEnumerator FadeNewMusicRoutine(AudioSource activeSource, AudioClip musicClip, float transitionDuration)
        {
            // validate source
            if (activeSource.isPlaying == false)
            {
                activeSource.Play();
            }
            // fade out
            float startingVolume = CurrentMusicVolume;
            float fadeOutTransitionDuration = transitionDuration / 2;
            for (float elapsedTime = 0; elapsedTime <= fadeOutTransitionDuration; elapsedTime += Time.deltaTime)
            {
                activeSource.volume = Mathf.Lerp(startingVolume, 0, elapsedTime / fadeOutTransitionDuration);
                yield return null;
            }
            // start new music track
            activeSource.Stop();
            activeSource.clip = musicClip;
            activeSource.Play();
            // fade in
            float fadeInTransitionDuration = transitionDuration / 2;
            for (float elapsedTime = 0; elapsedTime <= fadeInTransitionDuration; elapsedTime += Time.deltaTime)
            {
                activeSource.volume = Mathf.Lerp(0, CurrentMusicVolume, elapsedTime / fadeInTransitionDuration);
                yield return null;
            }
        }

        private IEnumerator CrossfadeNewMusicRoutine
            (AudioSource originalSource, AudioSource newSource, float transitionDuration)
        {
            float startingVolume = CurrentMusicVolume;
            for (float elapsedTime = 0.0f; elapsedTime <= transitionDuration; elapsedTime += Time.deltaTime)
            {
                originalSource.volume = Mathf.Lerp(CurrentMusicVolume, 0, elapsedTime / transitionDuration);
                newSource.volume = Mathf.Lerp(0, CurrentMusicVolume, elapsedTime / transitionDuration);
                yield return null;
            }

            originalSource.Stop();
        }

        private void SetupMusicSources()
        {
            _musicSource1 = gameObject.AddComponent<AudioSource>();
            _musicSource2 = gameObject.AddComponent<AudioSource>();

            _musicSource1.volume = CurrentMusicVolume;
            _musicSource2.volume = CurrentMusicVolume;
        }
    }
}


