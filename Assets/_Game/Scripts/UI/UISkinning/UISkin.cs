using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO refresh OnSkinUI with custom editor, so that we can preview without going in play mode
[ExecuteInEditMode()]
public class UISkin : MonoBehaviour
{
    [SerializeField] private UISkinData _skinData;

    protected UISkinData SkinData => _skinData;

    protected virtual void OnSkinUI()
    {

    }

    public virtual void Awake()
    {
        OnSkinUI();
    }
}
