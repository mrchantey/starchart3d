using UnityEngine;

namespace Ahoy.Compute
{

	[ExecuteAlways]
	[RequireComponent(typeof(ComputeInstance), typeof(MaterialInstance))]
	public class ComputeRenderer : MonoBehaviour
	{
		public RenderData renderData;

		[HideInInspector]
		public ComputeInstance computeInstance;
		[HideInInspector]
		public MaterialInstance materialInstance;
		public bool isInitialized { get; protected set; }

		void OnEnable()
		{
			computeInstance = GetComponent<ComputeInstance>();
			materialInstance = GetComponent<MaterialInstance>();
			Init();
		}

		public void Init()
		{
			int numThreads;
			ComputeShader computeTemplate;
			ComputeBuffer indexBuffer, vertexBuffer, positionBuffer;
			GraphicsBuffer indexBufferGraphics;
			renderData.GetData(out positionBuffer, out vertexBuffer, out indexBuffer, out indexBufferGraphics, out numThreads, out computeTemplate);

			computeInstance.Init(computeTemplate, numThreads);
			computeInstance.SetBuffer("vertices", vertexBuffer);
			computeInstance.SetBuffer("positions", positionBuffer);
			computeInstance.SetBuffer("indices", indexBuffer);

			// Debug.Log($"ComputeRenderer - data:\nThreads:\t{numThreads}\nPositions:\t{numPositions}\nIndices:   \t{numIndices}\nVertices:\t{numVertices}");

			materialInstance.Init(vertexBuffer, indexBufferGraphics);
			renderData.ApplyToShaders(computeInstance, materialInstance);
			isInitialized = true;
		}

		public void Render(Camera camera)
		{
			if (!isInitialized)
			{
				Debug.LogWarning($"MaterialInstance - not initialized");
				return;
			}
			computeInstance.Dispatch();
			materialInstance.Render(camera);
		}
	}
}