


using UnityEngine;
using System.Linq;



[CreateAssetMenu(menuName = "StarChart/Asset Generators/Star Mesh")]
public class StarMeshGenerator : AssetGenerator
{


    public StarDatabaseLoader database;
    [Range(2000, 30000)]
    public int starsPerMesh = 10000;

    protected override void GenerateAssets()
    {


        for (int i = 0; i < database.stars.Length; i += starsPerMesh)
        {
            string name = "stars " + (i / starsPerMesh);
            StarInfo[] subStars = database.stars.SubArray(i, starsPerMesh).ToArray();
            var mesh = CreateMesh(subStars, name);
            AssetUtility.SaveMeshAsset(folderPath, mesh);
        }

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