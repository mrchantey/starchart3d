


using UnityEngine;
using System.Linq;



[CreateAssetMenu(menuName = "StarChart/Asset Generators/Star Mesh")]
public class StarMeshGenerator : AssetGenerator
{


    public StarDatabaseLoader database;


    protected override void GenerateAssets()
    {

        var mesh = CreateMesh(database.stars, "stars");
        AssetUtility.SaveMeshAsset(folderPath, mesh);
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

        mesh.SetIndices(indicies, MeshTopology.Points, 0);

        return mesh;
    }

}