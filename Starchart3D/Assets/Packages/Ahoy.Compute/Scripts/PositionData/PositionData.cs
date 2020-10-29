using UnityEngine;

namespace Ahoy.Compute
{

	public abstract class PositionData : ScriptableObject
	{
		public abstract int numPositions { get; }
		public abstract Vector3[] GetPositions();
	}
	public abstract class IndexedPositionData : PositionData
	{
		public abstract int numIndices { get; }
		public abstract int[] GetIndices();
	}
}