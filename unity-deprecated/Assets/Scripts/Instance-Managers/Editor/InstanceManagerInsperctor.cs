

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InstanceManager), true)]
public class InstanceManagerInspector : Editor
{


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        InstanceManager im = (InstanceManager)target;

        if (GUILayout.Button("Generate and Instantiate"))
            im.GenerateAndInstantiatePrefab();
        if (GUILayout.Button("Instantiate"))
            im.InstantiatePrefab();
    }




}