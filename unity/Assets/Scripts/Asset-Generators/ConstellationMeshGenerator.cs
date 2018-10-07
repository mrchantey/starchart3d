

using UnityEngine;
using System.Linq;




[CreateAssetMenu(menuName = "StarChart/Asset Generators/Constellation Mesh")]
public class ConstellationMeshGenerator : AssetGenerator
{


    public ConstellationDatabaseLoader database;

    protected override void GenerateAssets()
    {
        database
        .constellations.Select(ci => CreateMesh(ci.stars, ci.name))
        .ForEach(cm => AssetUtility.SaveMeshAsset(folderPath, cm));

    }


    Mesh CreateMesh(StarInfo[] stars, string name)
    {
        var mesh = new Mesh();
        mesh.name = name;

        mesh.vertices = stars
        .Select(s => s.position)
        .ToArray();

        int[] indicies = stars
        .Select((s, i) => i)
        .ToArray();

        mesh.SetIndices(indicies, MeshTopology.Lines, 0);

        return mesh;
    }

}