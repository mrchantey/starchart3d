#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;

namespace Ahoy
{


	[CustomPropertyDrawer(typeof(Gen010Variable), true)]
	public class Gen010VariableDrawer : PropertyDrawer
	{

		public int numLines = 1;
		// Draw the property inside the given rect
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			label = EditorGUI.BeginProperty(position, label, property);
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
			EditorGUI.BeginChangeCheck();
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			//CODE STARTS HERE

			var height = base.GetPropertyHeight(property, label);
			//draw object field
			var rect1 = new Rect(position.x, position.y, position.width, height);
			EditorGUI.PropertyField(rect1, property, GUIContent.none);



			var name = property.name;
			var obj = property.serializedObject.targetObject;
			Type t = obj.GetType();
			var variableField = t.GetField(name);
			var variableObject = (Gen010Variable)variableField.GetValue(obj);
			SerializedObject variableSerializedObject = null;


			//if object not null, draw value field
			if (variableObject != null)
			{
				numLines = 2;
				var rect2 = new Rect(position.x, position.y + height, position.width, height);

				variableSerializedObject = new SerializedObject(variableObject);
				var valueSerializedProperty = variableSerializedObject.FindProperty("value");
				var useMinMax = variableSerializedObject.FindProperty("useMinMax").boolValue;

				if (useMinMax && valueSerializedProperty.propertyType == SerializedPropertyType.Float)
				{
					var min = variableSerializedObject.FindProperty("min").floatValue;
					var max = variableSerializedObject.FindProperty("max").floatValue;
					EditorGUI.Slider(rect2, valueSerializedProperty, min, max, GUIContent.none);
				}
				else if (useMinMax && valueSerializedProperty.propertyType == SerializedPropertyType.Integer)
				{
					var min = variableSerializedObject.FindProperty("min").intValue;
					var max = variableSerializedObject.FindProperty("max").intValue;
					EditorGUI.IntSlider(rect2, valueSerializedProperty, min, max, GUIContent.none);
				}
				else
				{
					EditorGUI.PropertyField(rect2, valueSerializedProperty, GUIContent.none);
				}
			}
			else
			{
				numLines = 1;
			}

			if (EditorGUI.EndChangeCheck())
			{
				property.serializedObject.ApplyModifiedProperties();
				if (variableSerializedObject != null)
					variableSerializedObject.ApplyModifiedProperties();
			}

			//AND ENDS HERE


			EditorGUI.indentLevel = indent;
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label) * numLines;
		}

	}



}
#endif