using UnityEngine;
using UnityEditor;


namespace Starchart3D
{



	[CustomEditor(typeof(DatabaseLoader), true)]
	public class DatabaseLoaderInspector : Editor
	{


		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			DatabaseLoader dl = (DatabaseLoader)target;

			if (GUILayout.Button("Load Database"))
				dl.LoadDatabase();
		}




	}
}