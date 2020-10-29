//
//
//	THS FILE IS AUTO GENERATED
//	DO NOT EDIT DIRECTLY
//



#if UNITY_EDITOR
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/using UnityEditor;
/*AUTO SCRIPT*/using UnityEngine;
/*AUTO SCRIPT*/using System;
/*AUTO SCRIPT*/using System.Reflection;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/namespace Ahoy
/*AUTO SCRIPT*/{
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/	[CustomPropertyDrawer(typeof(DoubleVariable), true)]
/*AUTO SCRIPT*/	public class DoubleVariableDrawer : PropertyDrawer
/*AUTO SCRIPT*/	{
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public int numLines = 1;
/*AUTO SCRIPT*/		// Draw the property inside the given rect
/*AUTO SCRIPT*/		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			label = EditorGUI.BeginProperty(position, label, property);
/*AUTO SCRIPT*/			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
/*AUTO SCRIPT*/			EditorGUI.BeginChangeCheck();
/*AUTO SCRIPT*/			var indent = EditorGUI.indentLevel;
/*AUTO SCRIPT*/			EditorGUI.indentLevel = 0;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/			//CODE STARTS HERE
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/			var height = base.GetPropertyHeight(property, label);
/*AUTO SCRIPT*/			//draw object field
/*AUTO SCRIPT*/			var rect1 = new Rect(position.x, position.y, position.width, height);
/*AUTO SCRIPT*/			EditorGUI.PropertyField(rect1, property, GUIContent.none);
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/			var name = property.name;
/*AUTO SCRIPT*/			var obj = property.serializedObject.targetObject;
/*AUTO SCRIPT*/			Type t = obj.GetType();
/*AUTO SCRIPT*/			var variableField = t.GetField(name);
/*AUTO SCRIPT*/			var variableObject = (DoubleVariable)variableField.GetValue(obj);
/*AUTO SCRIPT*/			SerializedObject variableSerializedObject = null;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/			//if object not null, draw value field
/*AUTO SCRIPT*/			if (variableObject != null)
/*AUTO SCRIPT*/			{
/*AUTO SCRIPT*/				numLines = 2;
/*AUTO SCRIPT*/				var rect2 = new Rect(position.x, position.y + height, position.width, height);
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/				variableSerializedObject = new SerializedObject(variableObject);
/*AUTO SCRIPT*/				var valueSerializedProperty = variableSerializedObject.FindProperty("value");
/*AUTO SCRIPT*/				var useMinMax = variableSerializedObject.FindProperty("useMinMax").boolValue;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/				if (useMinMax && valueSerializedProperty.propertyType == SerializedPropertyType.Float)
/*AUTO SCRIPT*/				{
/*AUTO SCRIPT*/					var min = variableSerializedObject.FindProperty("min").floatValue;
/*AUTO SCRIPT*/					var max = variableSerializedObject.FindProperty("max").floatValue;
/*AUTO SCRIPT*/					EditorGUI.Slider(rect2, valueSerializedProperty, min, max, GUIContent.none);
/*AUTO SCRIPT*/				}
/*AUTO SCRIPT*/				else if (useMinMax && valueSerializedProperty.propertyType == SerializedPropertyType.Integer)
/*AUTO SCRIPT*/				{
/*AUTO SCRIPT*/					var min = variableSerializedObject.FindProperty("min").intValue;
/*AUTO SCRIPT*/					var max = variableSerializedObject.FindProperty("max").intValue;
/*AUTO SCRIPT*/					EditorGUI.IntSlider(rect2, valueSerializedProperty, min, max, GUIContent.none);
/*AUTO SCRIPT*/				}
/*AUTO SCRIPT*/				else
/*AUTO SCRIPT*/				{
/*AUTO SCRIPT*/					EditorGUI.PropertyField(rect2, valueSerializedProperty, GUIContent.none);
/*AUTO SCRIPT*/				}
/*AUTO SCRIPT*/			}
/*AUTO SCRIPT*/			else
/*AUTO SCRIPT*/			{
/*AUTO SCRIPT*/				numLines = 1;
/*AUTO SCRIPT*/			}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/			if (EditorGUI.EndChangeCheck())
/*AUTO SCRIPT*/			{
/*AUTO SCRIPT*/				property.serializedObject.ApplyModifiedProperties();
/*AUTO SCRIPT*/				if (variableSerializedObject != null)
/*AUTO SCRIPT*/					variableSerializedObject.ApplyModifiedProperties();
/*AUTO SCRIPT*/			}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/			//AND ENDS HERE
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/			EditorGUI.indentLevel = indent;
/*AUTO SCRIPT*/			EditorGUI.EndProperty();
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			return base.GetPropertyHeight(property, label) * numLines;
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/	}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/}
#endif