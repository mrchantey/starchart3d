using UnityEngine;

namespace Ahoy.Compute
{

	[CreateAssetMenu(fileName = "Mesh Data", menuName = "Ahoy.Compute/Mesh Data", order = 0)]
	public class MeshData : PositionData
	{
		public Mesh mesh;
		protected override Vector3[] GetPositions() { return mesh.vertices; }
		// public override int[] GetIndices() { return mesh.GetIndices(0); }

	}
}