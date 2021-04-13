using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SoundSystem;

public class ScriptTester : MonoBehaviour
{
    [SerializeField] MusicEvent _song01;
    [SerializeField] MusicEvent _song02;

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Debug.Log("Play Song 01");
            _song01.Play(5f);
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Debug.Log("Play Song 02");
            _song02.Play(5f);
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            // remove music layer
            Debug.Log("Decrease Music Layer");
            MusicManager.Instance.DecreaseLayerLevel(5f);
            Debug.Log("ActiveLayer: " + MusicManager.Instance.ActiveLayerIndex);
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            // add new music layer
            Debug.Log("Increase Music Layer");
            MusicManager.Instance.IncreaseLayerLevel(5f);
            Debug.Log("ActiveLayer: " + MusicManager.Instance.ActiveLayerIndex);
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // stop the music
            Debug.Log("Stop the music");
            MusicManager.Instance.StopMusic(3);
        }
    }

}
