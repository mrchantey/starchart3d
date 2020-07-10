using UnityEngine;
using Ahoy;

namespace Starchart3D
{

	public class InstanceManager : MonoBehaviour
	{

		[HideInInspector]
		[SerializeField]
		GameObject starsInstance;
		[HideInInspector]
		[SerializeField]
		GameObject constellationsInstance;
		[HideInInspector]
		[SerializeField]
		GameObject constellationOverlayInstance;


		public StarDatabaseLoader starDatabaseLoader;
		public ConstellationDatabaseLoader constellationDatabaseLoader;


		public StarMeshGenerator starMeshGenerator;
		public ConstellationMeshGenerator constellationMeshGenerator;

		public MeshPrefabGenerator starPrefabGenerator;
		public MeshPrefabGenerator constellationPrefabGenerator;
		public ConstellationOverlayPrefabGenerator constellationOverlayPrefabGenerator;


		public void GenerateAndInstantiatePrefab()
		{
			starDatabaseLoader.LoadDatabase();
			//constellation database must load after star database
			constellationDatabaseLoader.LoadDatabase();

			starMeshGenerator.Generate();
			constellationMeshGenerator.Generate();

			starPrefabGenerator.Generate();
			constellationPrefabGenerator.Generate();

			constellationOverlayPrefabGenerator.Generate();

			InstantiatePrefab();
		}


		public void InstantiatePrefab()
		{
			if (starsInstance != null)
				GameObject.DestroyImmediate(starsInstance);
			if (constellationsInstance != null)
				GameObject.DestroyImmediate(constellationsInstance);
			if (constellationOverlayInstance != null)
				GameObject.DestroyImmediate(constellationOverlayInstance);

			var starPrefab = AssetUtility.GetAssetsAtPath<GameObject>(starPrefabGenerator.folderPath)[0];
			starsInstance = GameObject.Instantiate(starPrefab, Vector3.zero, Quaternion.identity, transform);

			var constellationPrefab = AssetUtility.GetAssetsAtPath<GameObject>(constellationPrefabGenerator.folderPath)[0];
			constellationsInstance = GameObject.Instantiate(constellationPrefab, Vector3.zero, Quaternion.identity, transform);

			var constellationOverlayPrefab = AssetUtility.GetAssetsAtPath<GameObject>(constellationOverlayPrefabGenerator.folderPath)[0];
			constellationOverlayInstance = GameObject.Instantiate(constellationOverlayPrefab, Vector3.zero, Quaternion.identity, transform);
		}


	}
}