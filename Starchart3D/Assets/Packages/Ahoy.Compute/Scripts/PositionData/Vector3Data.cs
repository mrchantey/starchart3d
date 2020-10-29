using UnityEngine;

namespace Ahoy.Compute
{

	[CreateAssetMenu(fileName = "Vector3 Data", menuName = "Ahoy.Compute/Vector3 Data", order = 0)]
	public class Vector3Data : PositionData
	{
		public Vector3[] data;
		public override int numPositions { get { return data.Length; } }
		public override Vector3[] GetPositions() { return data; }

	}
}