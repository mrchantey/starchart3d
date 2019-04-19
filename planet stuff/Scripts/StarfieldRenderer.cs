using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class StarfieldRenderer : AstroRenderer
{

    public StarCatalog starCatalog;

    [Range(1000, 50000)]
    public int maxStarsPerMesh = 10000;
    public int maxStarCount = 10;
    //public float radius = 1;

    public bool randomData;

    protected override void Render()
    {
        CreateMeshes(starCatalog.stars, maxStarCount, maxStarsPerMesh);
    }

    void CreateMeshes(StarInfo[] allStars, int maxStars, int starsPerMesh)
    {
        var stars = allStars.Take(Mathf.Min(maxStars, allStars.Length)).ToArray();
        var starGroups = GroupStars(stars, starsPerMesh);

        float maxDist = stars.Select(s => s.distance).Max();
        float minMag = stars.Select(s => s.magnitude).Min();
        float maxMag = stars.Select(s => s.magnitude).Max();
        float minAbsMag = stars.Select(s => s.absoluteMagnitude).Min();
        float maxAbsMag = stars.Select(s => s.absoluteMagnitude).Max();

        foreach (var starGroup in starGroups)
        {
            var mesh = CreateMesh(starGroup, maxDist, minMag, maxMag, minAbsMag, maxAbsMag);
            CreateMeshGameObject("Child Mesh", mesh, rendererMaterial);
        }
    }

    List<StarInfo>[] GroupStars(StarInfo[] stars, int starsPerMesh)
    {
        var starGroups = CreateStarGroups(stars.Length, starsPerMesh);

        for (int i = 0; i < stars.Length; i++)
        {
            int groupIndex = Mathf.FloorToInt(i / starsPerMesh);
            starGroups[groupIndex].Add(stars[i]);
        }
        return starGroups;
    }

    List<StarInfo>[] CreateStarGroups(int starCount, int starsPerMesh)
    {
        int groupCount = Mathf.CeilToInt(starCount / (float)starsPerMesh);
        var starGroups = new List<StarInfo>[groupCount];
        for (int i = 0; i < starGroups.Length; i++)
        {
            starGroups[i] = new List<StarInfo>();
        }
        return starGroups;
    }

    Mesh CreateMesh(List<StarInfo> stars, float maxDist, float minMag, float maxMag, float minAbsMag, float maxAbsMag)
    {
        Mesh mesh = new Mesh();
        mesh.name = "Star Mesh";
        var vertices = new Vector3[stars.Count() * 3];
        var normals = new Vector3[vertices.Length];
        var indicies = new int[vertices.Length];
        var uvMags = new Vector2[vertices.Length];
        var colors = new Color[vertices.Length];

        for (int i = 0; i < stars.Count(); i++)
        {
            int vi = i * 3;
            vertices[vi] = stars[i].position;
            normals[vi] = stars[i].velocity;
            uvMags[vi] = GetMagnitudes(stars[i], minMag, maxMag, minAbsMag, maxAbsMag);
            indicies[vi] = vi;
            colors[vi] = stars[i].color;
        }
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv2 = uvMags;
        mesh.triangles = indicies;
        mesh.colors = colors;
        //   mesh.RecalculateBounds();
        // mesh.RecalculateNormals();
        return mesh;
    }

    Vector2 GetMagnitudes(StarInfo star, float minMag, float maxMag, float minAbsMag, float maxAbsMag)
    {
        float mag = (star.magnitude - minMag) / (maxMag - minMag);
        //float mag = (star.magnitude / maxMag);
        float absMag = (star.absoluteMagnitude - minAbsMag) / (maxAbsMag - minAbsMag);
        return new Vector2(mag, absMag);
    }

}
