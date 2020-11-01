

using UnityEngine;

namespace Ahoy.Compute
{

	public class LineComputeRenderer : PositionComputeRenderer
	{


		protected override int numVerts { get { return numPositions * 2; } }
		protected override int numThreads
		{
			get
			{
				if (numPositions % 2 != 0)
					Debug.LogWarning($"LineComputeRenderer - Position Count Mismatch, final vertex will be truncated");
				// throw new System.Exception($"num positions mismatch");
				return numPositions / 2;
			}
		}

		protected override int[] GetIndices()
		{
			return GenerateQuadIndices(numPositions / 2);
		}

	}
}
