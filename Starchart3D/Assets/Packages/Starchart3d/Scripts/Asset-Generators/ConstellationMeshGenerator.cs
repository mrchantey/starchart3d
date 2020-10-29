using UnityEngine;
using System.Linq;
using Ahoy;

namespace Starchart3D
{



	[CreateAssetMenu(menuName = "Starchart3D/Asset Generators/Constellation Mesh")]
	public class ConstellationMeshGenerator : AssetGenerator
	{


		public ConstellationDatabaseLoader database;

		protected override void GenerateAssets()
		{
			database
			.constellations.Select(ci => CreateMesh(ci.stars, ci.name))
			.ForEach(cm => AssetUtility.SaveObjectAsset(folderPath, cm, ".mesh"));

		}


		Mesh CreateMesh(StarInfo[] stars, string name)
		{
			var mesh = new Mesh();
			mesh.name = name;

			mesh.vertices = stars
			.Select(s => s.position)
			.ToArray();

			mesh.normals = stars
			.Select(s => s.velocity)
			.ToArray();

			int[] indicies = stars
			.Select((s, i) => i)
			.ToArray();

			mesh.SetIndices(indicies, MeshTopology.Lines, 0);

			mesh.bounds = StarMath.CreateMaxBounds();

			return mesh;
		}

	}

}