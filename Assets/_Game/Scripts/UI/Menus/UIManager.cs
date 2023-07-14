using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIManager : MonoBehaviour
{
    public abstract void InitializeMenus();

    private void Start()
    {
        // all menus should start disabled, and activated as needed
        InitializeMenus();
    }
}

