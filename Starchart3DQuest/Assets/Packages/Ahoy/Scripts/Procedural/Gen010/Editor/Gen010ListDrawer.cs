#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

//reorderable list documentation: https://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/



namespace Ahoy
{

	[CustomPropertyDrawer(typeof(Gen010List), true)]
	public class Gen010ListDrawer : PropertyDrawer
	{
		public int numLines = 1;

		ReorderableList rList;
		Gen010List list;
		// gen010 defaultVal;

		void OnEnable()
		{

		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (list == null)
			{
				list = EditorUtility.GetPropertyObject<Gen010List>(property);
				rList = new ReorderableList(list, typeof(gen010), true, false, true, true);
				// rList.onAddCallback += data => { list.Add(defaultVal); };
				// rList.onChangedCallback += data=> {
				// };
			}

			numLines = 3 + list.Count;
			var title = new GUIContent($" {label.text}");
			var height = base.GetPropertyHeight(property, label);
			var rect = new Rect(position.x, position.y, position.width, height);
			EditorGUI.BeginChangeCheck();
			rList.DoList(rect);
			EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), title);

			if (EditorGUI.EndChangeCheck())
				property.serializedObject.ApplyModifiedProperties();

		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label) * numLines;
		}

	}
}
#endif