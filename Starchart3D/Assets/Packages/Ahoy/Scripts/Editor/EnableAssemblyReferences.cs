#if UNITY_EDITOR

using System.IO;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEditor;

// public class EnableAssemblyReferences
// {
// 	#pragma warning disable IDE0051 // Remove unused private members
// 		[DidReloadScripts]
// 		private static void OnScriptsReloaded()
// 		{
// 			foreach (var filename in Directory.GetFiles(".", "*.csproj"))
// 			{
// 				var csprojContent = File.ReadAllText(filename);
// 				var fixedCsprojContent = csprojContent.Replace("<ReferenceOutputAssembly>false</ReferenceOutputAssembly>", "<ReferenceOutputAssembly>true</ReferenceOutputAssembly>");
// 				if (csprojContent != fixedCsprojContent)
// 				{
// 					File.WriteAllText(filename, fixedCsprojContent);
// 					Debug.Log("Enabling Assembly References:\t" + filename);
// 				}
// 			}
// 		}
// 	#pragma warning restore IDE0051 // Remove unused private members
// }

// public class FIX : AssetPostprocessor
// {
// 	private static string OnGeneratedCSProject(string path, string content)
// 	{
// 		Debug.Log($"EnableAssemblyReferences - BANG");
// 		return content.Replace("<ReferenceOutputAssembly>false</ReferenceOutputAssembly>", "<ReferenceOutputAssembly>true</ReferenceOutputAssembly>");
// 	}
// }

#endif