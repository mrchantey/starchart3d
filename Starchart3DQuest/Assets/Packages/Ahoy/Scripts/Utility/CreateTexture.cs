#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Ahoy{
public class CreateTexture : MonoBehaviour
{
	[MenuItem("GameObject/Create Texture2D")]
	static void CreateMaterial()
	{
		// Create a simple material asset
		Texture2D tex = new Texture2D(256, 256);
		// Material material = new Material(Shader.Find("Specular"));
		AssetDatabase.CreateAsset(tex, "Assets/Texture.mat");

		// Print the path of the created asset
		// Debug.Log(AssetDatabase.GetAssetPath(material));
	}
}
}
#endif