using System;
using UnityEngine;
using UnityEngine.Rendering;
using Ahoy.Shaders;

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

		public bool applyShaderPropertiesOnDispatch = true;
		public bool instantiateTemplate = true;
		public ShaderPropertiesBase shaderProperties;

		public ShadowCastingMode castShadows = ShadowCastingMode.Off;
		public bool receiveShadows = false;
		public int layer = 1;

		public bool isInitialized { get; private set; }


		GraphicsBuffer indexBufferRef;

		public void Init(ComputeBuffer verticesBuffer, GraphicsBuffer indexBuffer)
		{
			material = instantiateTemplate ? new Material(materialTemplate) : materialTemplate;
			var numVerts = verticesBuffer.count;
			material.SetBuffer("vertices", verticesBuffer);
			if (shaderProperties != null)
				shaderProperties.Apply(material);
			indexBufferRef = indexBuffer;
			isInitialized = true;
		}

		public void Render(Camera camera = null)
		{

			if (shaderProperties != null & applyShaderPropertiesOnDispatch)
				shaderProperties.Apply(material);

			Graphics.DrawProcedural(
								material,
								bounds,
								MeshTopology.Triangles,
								indexBufferRef,
								indexBufferRef.count,
								1,
								camera,
								null,
								castShadows,
								receiveShadows,
								layer
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