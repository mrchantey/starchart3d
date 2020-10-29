using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR


namespace Ahoy
{


	public static class EditorUtility
	{

		[MenuItem("Ahoy/Reset Transform %t")]
		static void ResetTransform()
		{
			if (Selection.activeGameObject != null)
			{
				Selection.activeGameObject.transform.localPosition = Vector3.zero;
				Selection.activeGameObject.transform.localScale = Vector3.one;
				Selection.activeGameObject.transform.rotation = Quaternion.identity;
			}
		}

		public static T GetPropertyObject<T>(SerializedProperty property)
		{
			var name = property.name;
			var obj = property.serializedObject.targetObject;
			var type = obj.GetType();
			var variableField = type.GetField(name);
			return (T)variableField.GetValue(obj);
		}

	}
}
#endif