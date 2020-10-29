using UnityEngine;
using Ahoy;

namespace Starchart3D
{

	public class InstanceManager : MonoBehaviour
	{
		public bool debug = true;
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
			if (debug) Debug.Log($"InstanceManager - Databases Loaded..");

			starMeshGenerator.Generate();
			constellationMeshGenerator.Generate();
			if (debug) Debug.Log($"InstanceManager - Meshes Generated..");

			starPrefabGenerator.Generate();
			constellationPrefabGenerator.Generate();
			constellationOverlayPrefabGenerator.Generate();
			if (debug) Debug.Log($"InstanceManager - Prefabs Generated..");

			InstantiatePrefab();
		}

		void PurgeInstances()
		{
			if (starsInstance != null)
				GameObject.DestroyImmediate(starsInstance);
			if (constellationsInstance != null)
				GameObject.DestroyImmediate(constellationsInstance);
			if (constellationOverlayInstance != null)
				GameObject.DestroyImmediate(constellationOverlayInstance);
		}


		public void InstantiatePrefab()
		{
			PurgeInstances();
			var starPrefab = AssetUtility.GetAssetsAtPath<GameObject>(starPrefabGenerator.folderPath)[0];
			starsInstance = GameObject.Instantiate(starPrefab, Vector3.zero, Quaternion.identity, transform);

			var constellationPrefab = AssetUtility.GetAssetsAtPath<GameObject>(constellationPrefabGenerator.folderPath)[0];
			constellationsInstance = GameObject.Instantiate(constellationPrefab, Vector3.zero, Quaternion.identity, transform);

			var constellationOverlayPrefab = AssetUtility.GetAssetsAtPath<GameObject>(constellationOverlayPrefabGenerator.folderPath)[0];
			constellationOverlayInstance = GameObject.Instantiate(constellationOverlayPrefab, Vector3.zero, Quaternion.identity, transform);
			if (debug) Debug.Log($"InstanceManager - Instances Created..");
			if (debug) Debug.Log($"InstanceManager - Process Complete!");
		}


	}
}