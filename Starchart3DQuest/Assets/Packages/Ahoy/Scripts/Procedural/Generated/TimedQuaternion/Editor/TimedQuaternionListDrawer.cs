//
//
//	THS FILE IS AUTO GENERATED
//	DO NOT EDIT DIRECTLY
//



#if UNITY_EDITOR
/*AUTO SCRIPT*/using UnityEngine;
/*AUTO SCRIPT*/using UnityEditor;
/*AUTO SCRIPT*/using UnityEditorInternal;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*///reorderable list documentation: https://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/namespace Ahoy
/*AUTO SCRIPT*/{
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/	[CustomPropertyDrawer(typeof(TimedQuaternionList), true)]
/*AUTO SCRIPT*/	public class TimedQuaternionListDrawer : PropertyDrawer
/*AUTO SCRIPT*/	{
/*AUTO SCRIPT*/		public int numLines = 1;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		ReorderableList rList;
/*AUTO SCRIPT*/		TimedQuaternionList list;
/*AUTO SCRIPT*/		// TimedQuaternion defaultVal;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		void OnEnable()
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			if (list == null)
/*AUTO SCRIPT*/			{
/*AUTO SCRIPT*/				list = EditorUtility.GetPropertyObject<TimedQuaternionList>(property);
/*AUTO SCRIPT*/				rList = new ReorderableList(list, typeof(TimedQuaternion), true, false, true, true);
/*AUTO SCRIPT*/				// rList.onAddCallback += data => { list.Add(defaultVal); };
/*AUTO SCRIPT*/				// rList.onChangedCallback += data=> {
/*AUTO SCRIPT*/				// };
/*AUTO SCRIPT*/			}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/			numLines = 3 + list.Count;
/*AUTO SCRIPT*/			var title = new GUIContent($" {label.text}");
/*AUTO SCRIPT*/			var height = base.GetPropertyHeight(property, label);
/*AUTO SCRIPT*/			var rect = new Rect(position.x, position.y, position.width, height);
/*AUTO SCRIPT*/			EditorGUI.BeginChangeCheck();
/*AUTO SCRIPT*/			rList.DoList(rect);
/*AUTO SCRIPT*/			EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), title);
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/			if (EditorGUI.EndChangeCheck())
/*AUTO SCRIPT*/				property.serializedObject.ApplyModifiedProperties();
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			return base.GetPropertyHeight(property, label) * numLines;
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/	}
/*AUTO SCRIPT*/}
#endif