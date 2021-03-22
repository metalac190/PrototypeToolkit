using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] Canvas _canvas;

    public Canvas Canvas => _canvas;

    public virtual void Open()
    {
        _canvas.gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        _canvas.gameObject.SetActive(false);
    }

}

