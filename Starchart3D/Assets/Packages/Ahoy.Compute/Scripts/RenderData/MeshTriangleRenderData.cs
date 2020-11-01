// using UnityEngine;

// namespace Ahoy.Compute
// {

// 	public class TriangleComputeRenderer : ComputeRenderer<IndexedPositionData>
// 	{
// 		// public IndexedPositionData indexedPositionData;

// 		protected override int numVerts { get { return numPositions * 4; } }
// 		protected override int numThreads
// 		{
// 			get
// 			{
// 				var numIndices = shaderData.numIndices;
// 				if (numIndices % 3 != 0)
// 					throw new System.Exception($"num indices mismatch");
// 				return numIndices / 3;
// 			}
// 		}
// 		// protected override Vector3[] GetPositions() { return shaderData.GetPositions(); }
// 		protected override int[] GetIndices()
// 		{
// 			return shaderData.GetIndices();
// 		}
// 	}
// }