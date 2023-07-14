using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] Canvas _canvas;

    public Canvas Canvas => _canvas;

    // override this and add animations
    public virtual void Open()
    {
        _canvas.gameObject.SetActive(true);
    }

    // override this and add animations
    public virtual void Close()
    {
        _canvas.gameObject.SetActive(false);
    }

    // used for closing windows instantly, without animation
    public void CloseImmediate()
    {
        _canvas.gameObject.SetActive(false);
    }

    // used for opening windows instantly, without animation
    public void OpenImmediate()
    {
        _canvas.gameObject.SetActive(true);
    }
}

