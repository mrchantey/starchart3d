using UnityEngine;

namespace Ahoy.Compute
{

	public abstract class ShaderData : ScriptableObject { }

	public abstract class PositionData : ShaderData
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