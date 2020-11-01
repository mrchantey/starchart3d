using UnityEngine;

namespace Ahoy.Compute
{

	[CreateAssetMenu(fileName = "LineRenderData", menuName = "Ahoy.Compute/LineRenderData", order = 0)]
	public class LineRenderData : RenderData
	{

		protected override void GetRenderData(int numPositions, out int[] indices, out int numVertices, out int numThreads)
		{
			indices = GenerateQuadIndices(numPositions / 2);
			numVertices = numPositions * 2;
			if (numPositions % 2 != 0)
				Debug.LogWarning($"LineComputeRenderer - Position Count Mismatch, final vertex will be truncated");
			// throw new System.Exception($"num positions mismatch");
			numThreads = numPositions / 2;
		}
	}
}
