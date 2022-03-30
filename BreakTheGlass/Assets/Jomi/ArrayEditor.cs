using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Array))]
public class ArrayEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Array myScript = (Array)target;

        if (GUILayout.Button("Test"))
        {
            myScript.CreateArray();
        }
    }
}
