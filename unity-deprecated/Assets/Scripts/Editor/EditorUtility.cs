


using UnityEngine;
using UnityEditor;

public static class EditorUtility
{

    [MenuItem("Custom/Reset Transform %t")]
    static void ResetTransform()
    {
        if (Selection.activeGameObject != null)
        {
            Selection.activeGameObject.transform.position = Vector3.zero;
            Selection.activeGameObject.transform.localScale = Vector3.one;
            Selection.activeGameObject.transform.rotation = Quaternion.identity;
        }
    }


}