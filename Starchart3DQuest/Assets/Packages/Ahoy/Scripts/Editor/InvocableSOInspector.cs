using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR


namespace Ahoy
{


	[CustomEditor(typeof(InvocableSO), true)]
	[CanEditMultipleObjects]
	public class InvocableSOInspector : Editor
	{


		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			var invocable = (InvocableSO)target;

			if (GUILayout.Button("Invoke"))
				invocable.Invoke();
		}

	}
}

#endif