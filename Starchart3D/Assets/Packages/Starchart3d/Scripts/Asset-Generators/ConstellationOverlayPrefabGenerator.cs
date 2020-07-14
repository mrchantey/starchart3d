


using UnityEngine;
using Ahoy;



namespace Starchart3D
{
	[CreateAssetMenu(menuName = "Starchart3D/Asset Generators/Constellation Overlay")]
	public class ConstellationOverlayPrefabGenerator : AssetGenerator
	{

		public GameObject canvasPrefab;
		public GameObject overlayPrefab;


		public ConstellationDatabaseLoader databaseLoader;


		protected override void GenerateAssets()
		{
			var parent3d = new GameObject("Constellation Overlays");
			var parentCanvas = GameObject.Instantiate(canvasPrefab);
			parentCanvas.transform.SetParent(parent3d.transform, true);

			databaseLoader
			.constellations
				.ForEach(c => CreateTextOverlayInstance(c, parentCanvas.transform, parent3d.transform));
			// AssetUtility.SavePrefabAsset(folderPath, canvasInstance);
			AssetUtility.SavePrefabAsset(folderPath, parent3d);
		}

		GameObject CreateTextOverlayInstance(ConstellationInfo constellation, Transform parentCanvas, Transform parent3d)
		{
			var instance = GameObject.Instantiate(overlayPrefab);
			instance.transform.SetParent(parentCanvas, false);
			instance.GetComponent<ConstellationOverlayText>().SetConstellation(constellation, parent3d);
			instance.name = constellation.name;
			return instance;
		}
	}
}