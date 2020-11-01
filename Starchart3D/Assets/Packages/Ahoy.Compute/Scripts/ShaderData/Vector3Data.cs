using UnityEngine;

namespace Ahoy.Compute
{

	[CreateAssetMenu(fileName = "Vector3 Data", menuName = "Ahoy.Compute/Vector3 Data", order = 0)]
	public class Vector3Data : PositionData
	{
		public Vector3[] data;
		protected override Vector3[] GetPositions() { return data; }
	}
}