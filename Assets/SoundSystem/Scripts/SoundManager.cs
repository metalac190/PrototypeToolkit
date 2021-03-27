using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class SoundManager : SingletonMB<SoundManager>
    {
        [SerializeField] int _startingPoolSize = 5;

        SoundPool _soundPool;

        protected override void Awake()
        {
            _soundPool = new SoundPool(this.transform, _startingPoolSize);
        }

        #region Play Sounds

        public void PlayOneShot(SFXOneShot soundEvent, Vector3 soundPosition)
        {
            if (soundEvent.Clip == null)
            {
                Debug.LogWarning("SoundManager.PlayOneShot: no clip specified");
                return;
            }

            AudioSource newSource = _soundPool.Get();
            // setup
            newSource.clip = soundEvent.Clip;
            //TODO set Mixer
            newSource.priority = soundEvent.Priority;
            newSource.volume = soundEvent.Volume;
            newSource.pitch = soundEvent.Pitch;
            newSource.panStereo = soundEvent.StereoPan;
            newSource.spatialBlend = soundEvent.SpatialBlend;

            newSource.minDistance = soundEvent.AttenuationMin;
            newSource.maxDistance = soundEvent.AttenuationMax;

            newSource.transform.position = soundPosition;

            ActivatePooledSound(newSource);
        }

        public void PlayOneShot(AudioSource source)
        {
            if (source.clip == null)
            {
                Debug.LogWarning("SoundManager.PlayOneShot: no clip specified");
                return;
            }

            AudioSource newSource = _soundPool.Get();
            // setup
            newSource.clip = source.clip;
            //TODO set Mixer
            newSource.priority = source.priority;
            newSource.volume = source.volume;
            newSource.pitch = source.pitch;
            newSource.panStereo = source.panStereo;
            newSource.spatialBlend = source.spatialBlend;

            newSource.minDistance = source.minDistance;
            newSource.maxDistance = source.maxDistance;

            newSource.transform.position = source.transform.position;

            ActivatePooledSound(newSource);
        }

        private void ActivatePooledSound(AudioSource newSource)
        {
            newSource.gameObject.SetActive(true);
            newSource.Play();

            StartCoroutine(DisableAfterCompleteRoutine(newSource));
        }

        IEnumerator DisableAfterCompleteRoutine(AudioSource source)
        {
            // ensure that looping isn't false. We don't want to disable a looping sound
            source.loop = false;

            float clipDuration = source.clip.length;
            yield return new WaitForSeconds(clipDuration);
            // disable
            source.Stop();
            _soundPool.Return(source);
        }
        #endregion
    }
}
