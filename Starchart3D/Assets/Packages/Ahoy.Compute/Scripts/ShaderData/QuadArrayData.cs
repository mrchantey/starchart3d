using UnityEngine;

namespace Ahoy.Compute
{

	[CreateAssetMenu(fileName = "Quad Array Data", menuName = "Ahoy.Compute/Quad Array Data", order = 0)]
	public class QuadArrayData : PositionData
	{
		public int numQuads = 1;
		public float deltaWidth = 0.1f;

		// public override int numVertices { get { return numPositions * 4; } }

		protected override Vector3[] GetPositions()
		{
			var width = Mathf.FloorToInt(Mathf.Sqrt(numQuads));
			Vector3 offset = new Vector3(-1, -1, 0) * width / 2f * deltaWidth;
			var positions = numQuads.SelectArray(i =>
			{
				var x = i % width;
				var y = Mathf.FloorToInt(i / width);
				return offset + new Vector3(x, y, 0) * deltaWidth;
				// Random.insideUnitSphere * 100;
			});
			return positions;
		}
	}
}