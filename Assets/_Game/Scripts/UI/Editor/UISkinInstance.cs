using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UISkinInstance : Editor
{
    [MenuItem("GameObject/UISkin/Button")]
    public static void AddButton()
    {
        Create("Button");
    }

    static GameObject _clickedObject;

    private static GameObject Create(string objectName)
    {
        GameObject instance = Instantiate(Resources.Load<GameObject>(objectName));
        instance.name = objectName;
        _clickedObject = UnityEditor.Selection.activeGameObject as GameObject;
        if(_clickedObject != null)
        {
            instance.transform.SetParent(_clickedObject.transform, false);
        }

        return instance;
    }

}
