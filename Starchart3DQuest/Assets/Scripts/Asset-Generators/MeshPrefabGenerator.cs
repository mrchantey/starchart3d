using UnityEngine;
using Ahoy;

namespace Starchart3D
{
	[CreateAssetMenu(menuName = "Starchart3D/Asset Generators/Mesh Prefab")]
	public class MeshPrefabGenerator : AssetGenerator
	{

		public AssetGenerator meshGenerator;

		public string prefabName = "Mesh Prefab";

		public Material material;

		protected override void GenerateAssets()
		{
			var parentPrefab = new GameObject(prefabName);
			AssetUtility.GetAssetsAtPath<Mesh>(meshGenerator.folderPath)
			.ForEach(m => CreateMeshGameObject(m, parentPrefab));

			AssetUtility.SavePrefabAsset(folderPath, parentPrefab);
		}

		GameObject CreateMeshGameObject(Mesh mesh, GameObject parent)
		{
			var go = new GameObject(mesh.name);
			go.transform.parent = parent.transform;
			go.AddComponent<MeshFilter>().mesh = mesh;
			go.AddComponent<MeshRenderer>().material = material;
			return go;
		}

	}
}