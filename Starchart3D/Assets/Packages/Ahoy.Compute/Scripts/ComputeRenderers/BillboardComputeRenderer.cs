using UnityEngine;

namespace Ahoy.Compute
{

	public class BillboardComputeRenderer : PositionComputeRenderer
	{

		protected override int numVerts { get { return numPositions * 4; } }
		protected override int numThreads { get { return numPositions; } }

		protected override int[] GetIndices()
		{
			return GenerateQuadIndices(numPositions);
		}


	}
}