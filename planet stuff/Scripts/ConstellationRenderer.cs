using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConstellationRenderer : AstroRenderer
{

    public bool zodiacOnly;

    public ConstellationCatalog constellationCatalog;


    protected override void Render()
    {
        CreateConstellations();
    }

    void CreateConstellations()
    {
        var constellations = GetConstellations();
        foreach (var constellation in constellations)
        {
            var mesh = CreateMesh(constellation.stars);
            mesh.name = constellation.name + " Mesh";
            CreateMeshGameObject(constellation.name, mesh, rendererMaterial);
        }
    }

    IEnumerable<ConstellationInfo> GetConstellations()
    {
        var constellations = zodiacOnly
        ? constellationCatalog.constellations.Where(c => c.isZodiac)
        : constellationCatalog.constellations;
        return constellations.OrderBy(c => c.name);
    }

    Mesh CreateMesh(StarInfo[] stars)
    {
        int connectionCount = stars.Length / 2;
        Vector3[] vertices = new Vector3[connectionCount * 3];
        Vector3[] normals = new Vector3[vertices.Length];
        int[] triangles = new int[vertices.Length];
        for (int i = 0; i < connectionCount; i++)
        {
            int vi = i * 3;
            int pi = i * 2;
            vertices[vi] = stars[pi].position;
            vertices[vi + 1] = stars[pi + 1].position;
            normals[vi] = stars[pi].velocity;
            normals[vi + 1] = stars[pi + 1].velocity;
            triangles[vi] = vi;
            triangles[vi + 1] = vi + 1;
        }
        var mesh = new Mesh();
        mesh.name = "Constellation Mesh";
        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
        return mesh;
    }


}
