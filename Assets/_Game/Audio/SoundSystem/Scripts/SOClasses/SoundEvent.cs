using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio/SoundEvent", fileName = "SFX_")]
public class SoundEvent : ScriptableObject
{
    [Header("General Settings")]
    [SerializeField] AudioClip[] _possibleClips = new AudioClip[0];

    [SerializeField][MinMaxRange(0,1)]
    RangedFloat _volume = new RangedFloat(.8f, .8f);
    [SerializeField][MinMaxRange(0, 2)]
    RangedFloat _pitch = new RangedFloat(.95f, 1.05f);

    [SerializeField] AudioMixer _audioMixer = null;

    [Header("Attenuation Settings")]
    [Range(0, 1)][SerializeField]
    float _spatialBlend = 0;
    //TODO hide these fields if 2D is true
    [SerializeField] float _attenuationMin = 1;
    [SerializeField] float _attenuationMax = 500;

    public AudioClip Clip { get; private set; }
    public float Volume { get; private set; }
    public float Pitch { get; private set; }

    public float SpatialBlend => _spatialBlend;
    public float AttenuationMin => _attenuationMin;
    public float AttenuationMax => _attenuationMax;

    public AudioMixer Mixer => _audioMixer;

    public void PlayOneShot(Vector3 position)
    {
        if (_possibleClips.Length == 0)
        {
            Debug.LogWarning("SoundEvent.Play: no clips specified");
            return;
        }

        SetVariationValues();

        SoundManager.Instance.PlayOneShot(this, position);
    }

    public void Preview(AudioSource source)
    {
        if (_possibleClips.Length == 0) return;

        source.clip = _possibleClips[Random.Range(0, _possibleClips.Length)];
        source.volume = Random.Range(_volume.MinValue, _volume.MaxValue);
        source.pitch = Random.Range(_pitch.MinValue, _pitch.MaxValue);

        source.Play();
    }

    private void SetVariationValues()
    {
        Clip = _possibleClips[Random.Range(0, _possibleClips.Length)];
        Volume = Random.Range(_volume.MinValue, _volume.MaxValue);
        Pitch = Random.Range(_pitch.MinValue, _pitch.MaxValue);
    }
}
