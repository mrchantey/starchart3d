using UnityEngine;
using System.Collections.Generic;

namespace Ahoy.Compute
{

	public abstract class RenderData : ScriptableObject
	{
		public PositionData positionData;
		protected abstract void GetRenderData(int numPositions, out int[] indices, out int numVertices, out int numThreads);
		public virtual void ApplyToShaders(ComputeInstance computeInstance, MaterialInstance materialInstance) { positionData.ApplyToShaders(computeInstance, materialInstance); }

		public ComputeShader computeTemplate = null;
		List<ComputeBuffer> vertexBuffers = new List<ComputeBuffer>();
		ComputeBuffer indexBuffer;
		GraphicsBuffer indexBufferGraphics;

		int[] indices;
		int numVertices;
		int numThreads;
		bool isInitialized;

		public void GetData(
			out ComputeBuffer positionBuffer,
			out ComputeBuffer vertexBuffer,
			out ComputeBuffer indexBuffer,
			out GraphicsBuffer indexBufferGraphics,
			out int numThreads,
			out ComputeShader computeTemplate)
		{
			Initialize();
			positionBuffer = positionData.GetPositionsBuffer();
			indexBuffer = this.indexBuffer;
			indexBufferGraphics = this.indexBufferGraphics;
			numThreads = this.numThreads;
			computeTemplate = this.computeTemplate;

			vertexBuffer = new ComputeBuffer(numVertices, Vector4Extensions.stride);
			vertexBuffer.SetData(new Vector4[numVertices]);
			vertexBuffers.Add(vertexBuffer);
		}


		public void Initialize()
		{
			if (isInitialized)
				return;
			GetRenderData(positionData.GetNumPositions(), out indices, out numVertices, out numThreads);
			int numPositions = positionData.GetNumPositions();
			indexBuffer = new ComputeBuffer(indices.Length, sizeof(int));
			indexBuffer.SetData(indices);
			indexBufferGraphics = new GraphicsBuffer(GraphicsBuffer.Target.Index, indices.Length, sizeof(int));
			indexBufferGraphics.SetData(indices);
			isInitialized = true;
		}




		void Cleanup()
		{
			isInitialized = false;
			vertexBuffers.ForEach(b =>
			{
				if (b != null)
					b.Dispose();
			});
			vertexBuffers.Clear();
			if (indexBuffer != null)
				indexBuffer.Dispose();
			if (indexBufferGraphics != null)
				indexBufferGraphics.Dispose();

		}

		void OnDestroy() { Cleanup(); }
		void OnDisable() { Cleanup(); }

		public static int[] GenerateQuadIndices(int numQuads)
		{
			var numIndices = numQuads * 6;
			var indices = new int[numIndices];
			for (int qi = 0, vi = 0, ti = 0; qi < numQuads; qi++, vi += 4, ti += 6)
			{
				indices[ti] = vi;
				indices[ti + 1] = vi + 1;
				indices[ti + 2] = vi + 2;
				indices[ti + 3] = vi + 2;
				indices[ti + 4] = vi + 3;
				indices[ti + 5] = vi;
			}
			return indices;
		}

	}
}