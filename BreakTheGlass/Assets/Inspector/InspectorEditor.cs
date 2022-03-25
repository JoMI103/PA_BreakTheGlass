using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InspectorScript))]
public class InspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InspectorScript myScript = (InspectorScript)target;

        if (GUILayout.Button("Test"))
        {
            myScript.changeObject();
        }
    }
}
