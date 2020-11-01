using UnityEngine;

namespace Ahoy.Compute
{

	[CreateAssetMenu(fileName = "BillboardRenderData", menuName = "Ahoy.Compute/BillboardRenderData", order = 0)]
	public class BillboardRenderData : RenderData
	{

		protected override void GetRenderData(int numPositions, out int[] indices, out int numVertices, out int numThreads)
		{
			indices = GenerateQuadIndices(numPositions);
			numVertices = numPositions * 4;
			numThreads = numPositions;
		}


	}
}