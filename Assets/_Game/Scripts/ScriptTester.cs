using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SoundSystem;

public class ScriptTester : MonoBehaviour
{
    [SerializeField] MusicEvent _musicEvent;

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            _musicEvent.Play(1.5f);
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            
        }
    }

}
