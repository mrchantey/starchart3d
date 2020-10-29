using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR


namespace Ahoy
{

	[CustomPropertyDrawer(typeof(MinMaxAttribute))]
	public class MinMaxDrawer : PropertyDrawer
	{
		public int numLines = 2;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			MinMaxAttribute minMax = attribute as MinMaxAttribute;
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			var height = base.GetPropertyHeight(property, label);

			var rectMinMax = new Rect(position.x, position.y, position.width, height);
			var rectMin = new Rect(position.x + position.width * 0f, position.y + height, position.width * 0.4f, height);
			var rectMax = new Rect(position.x + position.width * 0.5f, position.y + height, position.width * 0.4f, height);

			if (property.propertyType == SerializedPropertyType.Vector2)
			{
				var vec = property.vector2Value;
				EditorGUI.MinMaxSlider(rectMinMax, ref vec.x, ref vec.y, minMax.minLimit, minMax.maxLimit);
				vec.x = EditorGUI.FloatField(rectMin, vec.x);
				vec.y = EditorGUI.FloatField(rectMax, vec.y);
				property.vector2Value = vec;
			}
			else
				EditorGUI.LabelField(position, label.text, "Use MinMax with Vector2.");
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label) * numLines;
		}

	}
}

#endif