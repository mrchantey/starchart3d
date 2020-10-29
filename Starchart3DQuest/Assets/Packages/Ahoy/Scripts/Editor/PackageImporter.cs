using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

#if UNITY_EDITOR
namespace Ahoy
{
	[CreateAssetMenu(fileName = "PackageImporter", menuName = "Ahoy/PackageImporter", order = 0)]
	[CanEditMultipleObjects]
	[ExecuteAlways]
	public class PackageImporter : InvocableSO
	{
		public bool selectContents;
		public List<string> paths;

		public bool debug;
		public bool purgePackagePaths;
		bool debugCallbacksAdded;

		public void Import()
		{
			if (debug && !debugCallbacksAdded)
			{
				AssetDatabase.importPackageCompleted += OnAdded;
				AssetDatabase.importPackageCancelled += OnCancelled;
				AssetDatabase.importPackageFailed += OnFailed;
				debugCallbacksAdded = true;
			}
			else if (!debug && debugCallbacksAdded)
			{
				AssetDatabase.importPackageCompleted -= OnAdded;
				AssetDatabase.importPackageCancelled -= OnCancelled;
				AssetDatabase.importPackageFailed -= OnFailed;
				debugCallbacksAdded = false;
			}
			for (int i = paths.Count - 1; i >= 0; i--)
			{
				ImportPackage(paths[i]);
			}
			AssetDatabase.Refresh();
		}

		public override void Invoke()
		{
			AssetUtility.RunMainThreadAction(Import);
		}

		void ImportPackage(string path)
		{
			if (purgePackagePaths)
			{
				var packageName = path.Split('/').Last();
				var assetPath = $"Assets/Packages/{packageName}";
				if (AssetUtility.PathExists(assetPath))
					AssetUtility.ClearAssetFolder(assetPath);
			}
			var packagePath = $"{path}.unitypackage";
			AssetDatabase.ImportPackage(packagePath, selectContents);
		}


		void OnAdded(string val)
		{
			Debug.Log($"package import succedded:\n{val}`");
		}
		void OnCancelled(string val)
		{
			Debug.Log($"package import cancelled:\n{val}`");
		}
		void OnFailed(string valA, string valB)
		{
			Debug.Log($"package import failed:\n{valA}\n{valB}`");
		}

	}
}
#endif