// using UnityEngine;

// namespace Ahoy.Compute
// {

// 	[CreateAssetMenu(fileName = "BillboardRenderData", menuName = "Ahoy.Compute/BillboardRenderData", order = 0)]
// 	public class BillboardRenderData : RenderData
// 	{

// 		public override int GetVertexCount(int numPositions, int numIndices)
// 		{
// 			return numPositions * 4;
// 		}

// 		protected override int[] GetIndices(int numPositions)
// 		{
// 			return GenerateQuadIndices(positionData.GetNumPositions());
// 		}

// 		protected override int numVerts { get { return (numPositions + 2) * 2; } }
// 		protected override int numThreads { get { return numPositions - 1; } }

// 		protected override int[] GetIndices()
// 		{
// 			return GenerateQuadIndices(numPositions - 1);
// 		}
// 	}

// }
// }