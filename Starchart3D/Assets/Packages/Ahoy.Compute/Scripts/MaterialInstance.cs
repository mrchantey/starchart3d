using System;
using UnityEngine;

namespace Ahoy
{

	public class MaterialInstance : MonoBehaviour
	{
		[SerializeField]
		Material materialTemplate = null;


		[HideInInspector]
		public Material material;

		[HideInInspector]
		public Bounds bounds = BoundsExtensions.MaxBounds;

		GraphicsBuffer indexBufferRef;

		public void Init(ComputeBuffer verticesBuffer, GraphicsBuffer indexBuffer)
		{
			material = new Material(materialTemplate);
			var numVerts = verticesBuffer.count;
			material.SetBuffer("vertices", verticesBuffer);
			indexBufferRef = indexBuffer;
		}

		public void Render()
		{
			Graphics.DrawProcedural(
								material,
								bounds,
								MeshTopology.Triangles,
								indexBufferRef,
								indexBufferRef.count
								);
		}

		public void SetBounds(Bounds bounds) { this.bounds = bounds; }
		public void SetMaterial(Material material) { this.material = material; }

		//this should only be done after initialization
		public void SetFloat(String name, float val) { material.SetFloat(name, val); }
		public void SetInt(String name, int val) { material.SetInt(name, val); }
		public void SetMatrix(String name, Matrix4x4 val) { material.SetMatrix(name, val); }
		public void SetVector(String name, Vector4 val) { material.SetVector(name, val); }
		public void SetBuffer(String name, ComputeBuffer val) { material.SetBuffer(name, val); }
		public void SetTexture(String name, Texture val) { material.SetTexture(name, val); }

	}
}