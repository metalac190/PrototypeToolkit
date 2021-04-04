using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    /// <summary>
    /// This class is a Singleton that helps maintain consistency across MusicPlayers in the scene.
    /// The main approach is to control 2 'MusicPlayers' that can activate/deactivate and blend with
    /// each other. New 'track layers' can be faded up to create additive music tracks that emulate
    /// stems. This can be useful for building new musical instrument layers based on game events
    /// to increase or decrease intensity.
    /// </summary>
    public class MusicManager : MonoBehaviour
    {
        #region Singleton
        private static bool _shuttingDown = false;
        private static object _lock = new object();

        private static MusicManager _instance;
        public static MusicManager Instance
        {
            get
            {
                if (_shuttingDown)
                {
                    return null;
                }
                lock (_lock)
                {
                    _instance = FindObjectOfType<MusicManager>();
                    // create it if it's not in the scene
                    if(_instance == null)
                    {
                        GameObject singletonGO = new GameObject();
                        _instance = singletonGO.AddComponent<MusicManager>();
                        singletonGO.name = "MusicManager (singleton)";

                        DontDestroyOnLoad(singletonGO);
                    }

                    return _instance;
                }
            }
        }

        void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }

            SetupMusicPlayers();
        }
        #endregion

        public const int MaxLayers = 3;

        // use 2 music sources so that we can do cross blending
        MusicPlayer _musicPlayer1 = null;
        MusicPlayer _musicPlayer2 = null;

        private bool _music1SourcePlaying = false;
        private Coroutine _musicBlendRoutine = null;
        private int _currentLayerLevel;     // used to maintain a 'level' for the musicplayer intensity
        private float _volume = .8f;

        public int ActiveLayerLevel => _currentLayerLevel;

        public float Volume
        {
            get => _volume;
            private set
            {
                value = Mathf.Clamp(value, 0, 1);
                _volume = value;
            }
        }
        public MusicPlayer ActivePlayer => (_music1SourcePlaying) ? _musicPlayer1 : _musicPlayer2;
        public MusicPlayer InactivePlayer => (_music1SourcePlaying) ? _musicPlayer2 : _musicPlayer1;

        #region PUBLIC METHODS
        public void SetVolume(float newVolume, float fadeTime)
        {
            // pass down volume command to MusicPlayer
            ActivePlayer.SetVolume(newVolume, fadeTime);
        }

        public void SetLayerLevel(int newLevel, float fadeTime)
        {
            newLevel = Mathf.Clamp(newLevel, 0, MaxLayers);
            _currentLayerLevel = newLevel;
            SetVolume(Volume, fadeTime);
        }

        public void PlayMusic(MusicEvent musicEvent, float fadeTime)
        {
            ActivePlayer.Stop(fadeTime);
            _music1SourcePlaying = !_music1SourcePlaying;
            ActivePlayer.Play(musicEvent, Volume, fadeTime);
        }
        #endregion

        void SetupMusicPlayers()
        {
            _musicPlayer1 = gameObject.AddComponent<MusicPlayer>();
            _musicPlayer2 = gameObject.AddComponent<MusicPlayer>();

            _musicPlayer1.SetVolume(Volume, 0);
            _musicPlayer2.SetVolume(Volume, 0);
        }

        /*
        private IEnumerator FadeMusicVolumeRoutine(AudioSource activeSource, float targetVolume, float fadeTime)
        {
            float startingVolume = Volume;
            // fade volume
            for (float elapsedTime = 0; elapsedTime <= fadeTime; elapsedTime += Time.deltaTime)
            {
                float newVolume = Mathf.Lerp(startingVolume, targetVolume, elapsedTime / fadeTime);
                activeSource.volume = newVolume;
                yield return null;
            }
            Volume = targetVolume;
        }

        private IEnumerator FadeNewMusicRoutine(AudioSource activeSource, AudioClip musicClip, float transitionDuration)
        {
            // validate source
            if (activeSource.isPlaying == false)
            {
                activeSource.Play();
            }
            // fade out
            float startingVolume = Volume;
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
                activeSource.volume = Mathf.Lerp(0, Volume, elapsedTime / fadeInTransitionDuration);
                yield return null;
            }
        }

        private IEnumerator CrossfadeNewMusicRoutine
            (AudioSource originalSource, AudioSource newSource, float transitionDuration)
        {
            float startingVolume = Volume;
            for (float elapsedTime = 0.0f; elapsedTime <= transitionDuration; elapsedTime += Time.deltaTime)
            {
                originalSource.volume = Mathf.Lerp(Volume, 0, elapsedTime / transitionDuration);
                newSource.volume = Mathf.Lerp(0, Volume, elapsedTime / transitionDuration);
                yield return null;
            }

            originalSource.Stop();
        }
        */
    }
}


