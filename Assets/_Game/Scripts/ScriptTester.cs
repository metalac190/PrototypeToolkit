using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptTester : MonoBehaviour
{
    [SerializeField] SoundEvent _soundEvent;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _soundEvent.PlayOneShot(this.transform.position);
        }
    }

}
