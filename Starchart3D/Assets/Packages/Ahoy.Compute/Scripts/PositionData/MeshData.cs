using UnityEngine;

namespace Ahoy.Compute
{

	[CreateAssetMenu(fileName = "Mesh Data", menuName = "Ahoy.Compute/Mesh Data", order = 0)]
	public class MeshData : IndexedPositionData
	{
		public Mesh mesh;
		public override int numPositions { get { return mesh.vertexCount; } }
		public override int numIndices { get { return (int)mesh.GetIndexCount(0); } }
		public override Vector3[] GetPositions() { return mesh.vertices; }
		public override int[] GetIndices() { return mesh.GetIndices(0); }

	}
}