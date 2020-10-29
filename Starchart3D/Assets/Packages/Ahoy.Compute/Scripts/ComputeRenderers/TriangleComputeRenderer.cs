using UnityEngine;

namespace Ahoy.Compute
{

	public class TriangleComputeRenderer : ComputeRenderer
	{
		public IndexedPositionData indexedPositionData;

		protected override int numVerts { get { return numPositions * 4; } }
		protected override int numThreads
		{
			get
			{
				var numIndices = indexedPositionData.numIndices;
				if (numIndices % 3 != 0)
					throw new System.Exception($"num indices mismatch");
				return numIndices / 3;
			}
		}
		// protected override Vector3[] GetPositions() { return positionData.GetPositions(); }
		protected override int[] GetIndices()
		{
			return indexedPositionData.GetIndices();
		}
	}
}