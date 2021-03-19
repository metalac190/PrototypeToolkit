using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTester : MonoBehaviour
{
    [SerializeField] TransitionScreenFader _transitionFaderPrefab;
    [SerializeField] ColorFlasher _colorFlash;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TransitionScreenFader.PlayTransition(_transitionFaderPrefab, 1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _colorFlash.Flash();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _colorFlash.Flash(Color.blue);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _colorFlash.StopFlash();
        }
    }

}
