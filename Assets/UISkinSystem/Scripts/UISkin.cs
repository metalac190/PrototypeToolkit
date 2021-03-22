using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO refresh OnSkinUI with custom editor, so that we can preview without going in play mode
[ExecuteInEditMode()]
public abstract class UISkin : MonoBehaviour
{
    [SerializeField] private UISkinData _skinData;

    protected abstract void OnSkinUI(UISkinData data);

    private void Reset()
    {
        OnSkinUI(_skinData);
    }
}
