using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SelectParent : EditorWindow
{

    [MenuItem("Edit/Select parent &a")]
    static void SelectParentOfObject()
    {
        Selection.activeGameObject = Selection.activeGameObject.transform.parent.gameObject;

    }
}