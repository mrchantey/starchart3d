using System.IO;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Ahoy
{
	public static class AssetUtility
	{
		public static void RunMainThreadAction(System.Action action)
		{
			var go = new GameObject("temp");
			var eve = go.AddComponent<MainThreadEvent>();
			eve.action = action;
		}

		public static bool PathExists(string assetPath)
		{
#if UNITY_EDITOR
			return AssetDatabase.AssetPathToGUID(assetPath) != "";
#else
			return false;
#endif
		}

		public static void ClearAssetFolder(string folderPath)
		{
#if UNITY_EDITOR
			GetAssetPaths(folderPath)
			  .ForEach(path => AssetDatabase.DeleteAsset(path));
#endif
		}

		public static string[] GetAssetPaths(string folderPath)
		{
#if UNITY_EDITOR
			return AssetDatabase.FindAssets("", new[] { folderPath })
			  .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
			  .ToArray();
#else
			  return null;
#endif
		}

		public static T[] GetAssetsAtPath<T>(string folderPath) where T : UnityEngine.Object
		{
#if UNITY_EDITOR
			return GetAssetPaths(folderPath)
				.Select(p => AssetDatabase.LoadAssetAtPath<T>(p))
				.ToArray();
#else
return null;
#endif

		}

		public static string GetSelectedPath()
		{
#if UNITY_EDITOR
			// var path = "Assets";
			var obj = Selection.activeObject;
			if (obj == null)
				return "Assets";
			else
			{
				return AssetDatabase.GetAssetPath(obj);
			}
#else
			return "";
#endif
		}


		public static string GetAssetName(UnityEngine.Object obj)
		{
#if UNITY_EDITOR
			var path = AssetDatabase.GetAssetPath(obj);
			return Path.GetFileNameWithoutExtension(path);
#else
return "";
#endif

		}


		// 		public static void SaveMeshAsset(string folderPath, Mesh mesh)
		// 		{
		// #if UNITY_EDITOR
		// 			string assetPath = folderPath + "/" + mesh.name + ".mesh";
		// 			AssetDatabase.CreateAsset(mesh, assetPath);
		// #endif
		// 		}
		public static void SaveObjectAsset(Object obj, string extension = ".asset")
		{
#if UNITY_EDITOR
			string assetPath = $"Assets/{obj.name}{extension}";
			AssetDatabase.CreateAsset(obj, assetPath);
#endif
		}
		public static void SaveObjectAsset(string folderPath, Object obj, string extension = ".asset")
		{
#if UNITY_EDITOR
			string assetPath = $"{folderPath}/{obj.name}{extension}";
			AssetDatabase.CreateAsset(obj, assetPath);
#endif
		}

		public static void SavePrefabAsset(string folderPath, GameObject instance)
		{
#if UNITY_EDITOR
			string assetPath = folderPath + "/" + instance.name + ".prefab";
			PrefabUtility.SaveAsPrefabAsset(instance, assetPath);
			GameObject.DestroyImmediate(instance);
#endif
		}
	}

}