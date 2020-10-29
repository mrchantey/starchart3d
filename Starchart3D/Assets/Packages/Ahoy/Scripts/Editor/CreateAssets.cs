using UnityEngine;
using UnityEditor;
using System.Linq;
#if UNITY_EDITOR

namespace Ahoy
{

	public static class CreateAssets
	{


		[MenuItem("Assets/Create/Ahoy/Asset/Texture 2D")]
		public static void CreateTexture2D()
		{
			var path = AssetUtility.GetSelectedPath();
			var tex = new Texture2D(256, 256);
			tex.name = "New Texture2D";
			AssetUtility.SaveObjectAsset(path, tex);
		}
		[MenuItem("Assets/Create/Ahoy/Asset/Line Mesh - Right")]
		public static void CreateLineMeshRight()
		{
			var path = AssetUtility.GetSelectedPath();
			var mesh = new Mesh();
			mesh.name = "Line Mesh - Right";
			mesh.vertices = new Vector3[] { Vector3.left * 0.5f, Vector3.right * 0.5f };
			mesh.normals = new Vector3[] { Vector3.up, Vector3.up };
			mesh.SetIndices(new int[] { 0, 1 }, MeshTopology.Lines, 0);
			mesh.RecalculateBounds();
			AssetUtility.SaveObjectAsset(path, mesh, ".mesh");
		}
		[MenuItem("Assets/Create/Ahoy/Asset/Line Mesh - Forward")]
		public static void CreateLineMeshForward()
		{
			var path = AssetUtility.GetSelectedPath();
			var mesh = new Mesh();
			mesh.name = "Line Mesh - Forward";
			mesh.vertices = new Vector3[] { Vector3.back * 0.5f, Vector3.forward * 0.5f };
			mesh.normals = new Vector3[] { Vector3.up, Vector3.up };
			mesh.SetIndices(new int[] { 0, 1 }, MeshTopology.Lines, 0);
			mesh.RecalculateBounds();
			AssetUtility.SaveObjectAsset(path, mesh, ".mesh");
		}
		[MenuItem("Assets/Create/Ahoy/Asset/Point Mesh - Quad")]
		public static void CreatePointMeshQuad()
		{
			var path = AssetUtility.GetSelectedPath();
			var mesh = new Mesh();
			mesh.name = "Point Mesh - Quad";
			var verts = new Vector3[] {
				Vector3.down * 0.5f + Vector3.left * 0.5f,
				Vector3.down * 0.5f + Vector3.right * 0.5f,
				Vector3.up * 0.5f + Vector3.left * 0.5f,
				Vector3.up * 0.5f + Vector3.right * 0.5f                 };
			mesh.vertices = verts;
			mesh.normals = verts.Select(v => v.normalized).ToArray();
			mesh.SetIndices(new int[] { 0, 1, 2, 3 }, MeshTopology.Points, 0);
			mesh.RecalculateBounds();
			AssetUtility.SaveObjectAsset(path, mesh, ".mesh");
		}



		[MenuItem("Assets/Create/Ahoy/Asset/Default Color Materials")]
		public static void CreateDefaultColorMaterials()
		{
			var path = AssetUtility.GetSelectedPath();
			CreateMaterial(new Color(1f, 1f, 1f), "White", path);
			CreateMaterial(new Color(0.75f, 0.75f, 0.75f), "Light Grey", path);
			CreateMaterial(new Color(0.5f, 0.5f, 0.5f), "Grey", path);
			CreateMaterial(new Color(0.25f, 0.25f, 0.25f), "Dark Grey", path);
			CreateMaterial(new Color(0f, 0f, 0f), "Black", path);
			CreateMaterial(new Color(1f, 0, 0), "Red", path);
			CreateMaterial(new Color(0.5f, 0, 0), "Dark Red", path);
			CreateMaterial(new Color(1f, 0.5f, 0.5f), "Light Red", path);
			CreateMaterial(new Color(0, 1f, 0), "Green", path);
			CreateMaterial(new Color(0, 0.5f, 0), "Dark Green", path);
			CreateMaterial(new Color(0.5f, 1f, 0.5f), "Light Green", path);
			CreateMaterial(new Color(0, 0, 1f), "Blue", path);
			CreateMaterial(new Color(0, 0, 0.5f), "Dark Blue", path);
			CreateMaterial(new Color(0.5f, 0.5f, 1f), "Light Blue", path);
			CreateMaterial(new Color(0, 1f, 1f), "Cyan", path);
			CreateMaterial(new Color(0, 0.5f, 0.5f), "Dark Cyan", path);
			CreateMaterial(new Color(0.5f, 1f, 1f), "Light Cyan", path);
			CreateMaterial(new Color(1f, 1f, 0), "Yellow", path);
			CreateMaterial(new Color(0.5f, 0.5f, 0), "Dark Yellow", path);
			CreateMaterial(new Color(1f, 1f, 0.5f), "Light Yellow", path);
			CreateMaterial(new Color(1, 0, 1), "Magenta", path);
			CreateMaterial(new Color(0.5f, 0, 0.5f), "Dark Magenta", path);
			CreateMaterial(new Color(1f, 0.5f, 1f), "Light Magenta", path);
		}

		public static void CreateMaterial(Color color, string name, string path)
		{
			var matLit = new Material(Shader.Find("Universal Render Pipeline/Lit"));
			// matLit.color = color;
			matLit.SetColor("_BaseColor", color);
			matLit.name = "Lit " + name;
			AssetUtility.SaveObjectAsset(path, matLit);
			var matUnlit = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
			// matUnlit.color = color;
			matUnlit.SetColor("_BaseColor", color);
			matUnlit.name = "Unlit " + name;
			AssetUtility.SaveObjectAsset(path, matUnlit);
			Debug.Log($"Material Created: {name}");
		}


		[MenuItem("Ahoy/Bake Mesh")]
		static void BakeMesh()
		{
			var obj = Selection.activeObject;
			if (obj == null || obj.GetType() != typeof(Mesh))
				return;
			var copy = Object.Instantiate(obj);
			AssetUtility.SaveObjectAsset((Mesh)copy, ".mesh");
		}

	}

}
#endif