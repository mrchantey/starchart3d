using UnityEngine;
using System.Linq;

namespace Ahoy.Shaders
{

	public class ShaderManager : MonoBehaviour
	{

		public Material material;
		[Range(1000, 65532)]
		public int maxVertsPerMesh = 65532;
		public MeshTopology meshTopology = MeshTopology.Points;
		public bool updateMaterials;
		protected Material[] matInstances;

		void Update()
		{
			if (matInstances == null || !updateMaterials)
				return;
			UpdateMaterials();
		}

		protected virtual void UpdateMaterials()
		{
			var color = material.GetColor("_Color");
			var fixedSize = material.GetFloat("_FixedSize");
			var radius = material.GetFloat("_Radius");
			matInstances.ForEach(i =>
			{
				// i.CopyPropertiesFromMaterial(material);
				i.SetColor("_Color", color);
				i.SetFloat("_FixedSize", fixedSize);
				i.SetFloat("_Radius", radius);
			});
		}

		public void Init(int numPoints)
		{
			// int numPoints = buff.count;

			int numMeshes = Mathf.CeilToInt((float)numPoints / maxVertsPerMesh);
			matInstances = new Material[numMeshes];

			var allVerts = new Vector3[numPoints];
			var bounds = Vector3.one * 100200300;
			allVerts = allVerts.Select(v => bounds.RandomInsideExtents()).ToArray();

			// Debug.Log($"ShaderManager - bang {numPoints}\t {numMeshes}\t {numPoints / maxVertsPerMesh}");
			for (int mi = 0, vi = 0; mi < numMeshes; mi++, vi += maxVertsPerMesh)
			{
				var go = new GameObject($"Mesh Chunk {mi + 1}");
				go.transform.parent = transform;

				var mesh = new Mesh();
				mesh.name = ($"Mesh {mi + 1}");
				var meshFilter = go.AddComponent<MeshFilter>();
				meshFilter.mesh = mesh;
				int remainingVerts = numPoints - vi;
				int numVerts = remainingVerts < maxVertsPerMesh ? remainingVerts : maxVertsPerMesh;
				var subVerts = allVerts.Skip(vi).Take(numVerts).ToArray();
				var indices = subVerts.Select((v, i) => i).ToArray();
				mesh.vertices = subVerts;
				mesh.SetIndices(indices, meshTopology, 0);
				mesh.RecalculateBounds();

				var meshRenderer = go.AddComponent<MeshRenderer>();
				meshRenderer.material = material;
				matInstances[mi] = meshRenderer.material;
				meshRenderer.material.SetInt("bufferOffset", vi);
				// meshRenderer.material.SetBuffer("smartPointBuffer", buff);
			}

			// Debug.Log($"SmartPointShaderManager - Initialized, mesh count: {numMeshes}\tparticle count: {camDesc.numPixels}");
		}


	}

}