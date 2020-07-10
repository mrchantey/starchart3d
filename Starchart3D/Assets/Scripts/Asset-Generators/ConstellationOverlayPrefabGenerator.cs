


using UnityEngine;
using Ahoy;



namespace Starchart3D
{
	[CreateAssetMenu(menuName = "StarChart/Asset Generators/Constellation Overlay")]
	public class ConstellationOverlayPrefabGenerator : AssetGenerator
	{

		public GameObject canvasPrefab;
		public GameObject overlayPrefab;


		public ConstellationDatabaseLoader databaseLoader;


		protected override void GenerateAssets()
		{
			var canvasInstance = GameObject.Instantiate(canvasPrefab);

			databaseLoader
			.constellations
				.ForEach(c => CreateTextOverlayInstance(c, canvasInstance.transform));
			AssetUtility.SavePrefabAsset(folderPath, canvasInstance);
		}

		GameObject CreateTextOverlayInstance(ConstellationInfo constellation, Transform parent)
		{
			var instance = GameObject.Instantiate(overlayPrefab);
			instance.transform.SetParent(parent, false);
			instance.GetComponent<ConstellationOverlayText>().SetConstellation(constellation);
			instance.name = constellation.name;
			return instance;
		}
	}
}