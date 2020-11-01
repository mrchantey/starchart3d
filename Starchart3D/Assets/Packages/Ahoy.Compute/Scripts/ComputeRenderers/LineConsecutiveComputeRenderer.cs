using UnityEngine;

namespace Ahoy.Compute
{

	public class LineConsecutiveComputeRenderer : PositionComputeRenderer
	{

		//TODO FIX THIS DANG THING

		protected override int numVerts { get { return (numPositions + 2) * 2; } }
		protected override int numThreads { get { return numPositions - 1; } }

		protected override int[] GetIndices()
		{
			return GenerateQuadIndices(numPositions - 1);
		}
	}
}