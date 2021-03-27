using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SoundSystem;

public class ScriptTester : MonoBehaviour
{
    [SerializeField] SFXOneShot _sfx;

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            _sfx.PlayOneShot(Vector3.zero);
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            
        }
    }

}
