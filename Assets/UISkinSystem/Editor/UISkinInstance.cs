using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UISkinInstance : Editor
{
    static string _buttonInstanceName = "Button_btn";
    static string _buttonPrefabName = "UISkin_btn";

    [MenuItem("GameObject/UISkin/Button")]
    public static void AddButton()
    {
        Create(_buttonPrefabName);
    }

    static GameObject _clickedObject;

    private static GameObject Create(string objectName)
    {
        GameObject instance = Instantiate(Resources.Load<GameObject>(objectName));
        instance.name = _buttonInstanceName;
        _clickedObject = UnityEditor.Selection.activeGameObject as GameObject;
        if(_clickedObject != null)
        {
            instance.transform.SetParent(_clickedObject.transform, false);
        }

        return instance;
    }

}
