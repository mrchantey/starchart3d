using UnityEngine;

namespace Ahoy.Compute
{

	[RequireComponent(typeof(ComputeInstance), typeof(MaterialInstance))]
	public abstract class ComputeRenderer : InvocableMono
	{
		// public bool debug = true;
		public PositionData positionData;
		[HideInInspector]
		public ComputeInstance computeInstance;
		[HideInInspector]
		public MaterialInstance materialInstance;

		ComputeBuffer positionsBuffer;
		ComputeBuffer verticesBuffer;
		ComputeBuffer indicesBuffer;
		GraphicsBuffer indicesBufferGraphics;

		protected virtual Vector3[] GetPositions() { return positionData.GetPositions(); }
		protected abstract int[] GetIndices();
		protected abstract int numVerts { get; }
		protected abstract int numThreads { get; }
		protected int numPositions { get { return positionData.numPositions; } }

		protected virtual void OnInit() { }

		void OnEnable()
		{
			computeInstance = GetComponent<ComputeInstance>();
			materialInstance = GetComponent<MaterialInstance>();
		}

		public override void Invoke()
		{

			Cleanup();

			var positions = GetPositions();
			var numPositions = positions.Length;
			positionsBuffer = new ComputeBuffer(numPositions, Vector3Extensions.stride);
			positionsBuffer.SetData(positions);

			var indices = GetIndices();
			var numIndices = indices.Length;
			indicesBuffer = new ComputeBuffer(numIndices, sizeof(int));
			indicesBuffer.SetData(indices);
			indicesBufferGraphics = new GraphicsBuffer(GraphicsBuffer.Target.Index, indices.Length, sizeof(int));
			indicesBufferGraphics.SetData(indices);


			var numVertices = numVerts;
			verticesBuffer = new ComputeBuffer(numVertices, Vector4Extensions.stride);
			verticesBuffer.SetData(new Vector4[numVertices]);

			computeInstance.Init(numThreads);

			computeInstance.SetBuffer("positions", positionsBuffer);
			computeInstance.SetBuffer("vertices", verticesBuffer);
			computeInstance.SetBuffer("indices", indicesBuffer);

			// Debug.Log($"ComputeRenderer - data:\nThreads:\t{numThreads}\nPositions:\t{numPositions}\nIndices:   \t{numIndices}\nVertices:\t{numVertices}");

			materialInstance.Init(verticesBuffer, indicesBufferGraphics);

			OnInit();

		}

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


		protected virtual void Cleanup()
		{
			if (positionsBuffer != null)
				positionsBuffer.Dispose();
			if (verticesBuffer != null)
				verticesBuffer.Dispose();
			if (indicesBuffer != null)
				indicesBuffer.Dispose();
			if (indicesBufferGraphics != null)
				indicesBufferGraphics.Dispose();

		}

		void OnDestroy() { Cleanup(); }


	}
}