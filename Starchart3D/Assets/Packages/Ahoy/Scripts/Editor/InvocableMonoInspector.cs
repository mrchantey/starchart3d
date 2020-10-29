using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

namespace Ahoy
{


	[CustomEditor(typeof(InvocableMono), true)]
	[CanEditMultipleObjects]
	public class InvocableMonoInspector : Editor
	{

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();


			var invocable = (InvocableMono)target;

			if (GUILayout.Button("Invoke"))
				invocable.Invoke();
		}

	}
}
#endif