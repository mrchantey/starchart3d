

using UnityEngine;
using UnityEditor;

namespace Starchart3D
{

	[CustomEditor(typeof(AssetGenerator), true)]
	public class AssetGeneratorInspector : Editor
	{


		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			AssetGenerator ag = (AssetGenerator)target;

			if (GUILayout.Button("Generate"))
				ag.Generate();
		}




	}
}