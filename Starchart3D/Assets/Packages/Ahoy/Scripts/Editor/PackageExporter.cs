#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Ahoy

{
	[CreateAssetMenu(fileName = "PackageExporter", menuName = "Ahoy/PackageExporter", order = 0)]
	[CanEditMultipleObjects]
	public class PackageExporter : InvocableSO
	{

		public bool debug;
		public bool selectContents;
		public string assetPath = "Assets/Packages";
		public string fileName = "../../unity-packages/mypkg";

		public override void Invoke()
		{
			AssetDatabase.ExportPackage(assetPath, $"{fileName}.unitypackage", ExportPackageOptions.Recurse);
			if (debug) Debug.Log($"Package Export Success! - {assetPath}");
		}

	}
}
#endif